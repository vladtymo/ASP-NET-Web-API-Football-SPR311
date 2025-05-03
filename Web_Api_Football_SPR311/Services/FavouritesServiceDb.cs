using System.Security.Claims;
using Core.Interfaces;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Web_Api_Football_SPR311;

public class FavouritesServiceDb(IHttpContextAccessor accessor, FootballDbContext context) : IFavoriteService
{
    private bool IsAuthenticated => _userId != null;
    
    private readonly string? _userId = accessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    private User? User => context.Users
        .SingleOrDefault(u => u.Id == _userId);
    private User? UserWithFavoriteItems => context.Users
        .Include(x => x.FavoriteItems)
        .SingleOrDefault(u => u.Id == _userId);
    
    private User? UserWithTeams => context.Users
        .Include(x => x.FavoriteItems)
        .ThenInclude(x => x.Team)
        .SingleOrDefault(u => u.Id == _userId);

    public List<int> GetIds()
    {
        if (!IsAuthenticated) return new List<int>();
        
        return UserWithFavoriteItems
            .FavoriteItems.Select(x => x.TeamId).ToList();
    }
    
    public List<Team> GetAll()
    {
        if (!IsAuthenticated) return new List<Team>();
        
        return UserWithTeams.FavoriteItems.Select(x => x.Team!).ToList();
    }

    public void Add(int id)
    {
        if (!IsAuthenticated) return;
        if (context.FavoriteItems.Find(_userId, id) != null)
            return;
        
        var item = new FavoriteItem()
        {
            TeamId = id,
            UserId = _userId
        };
        
        context.FavoriteItems.Add(item);
        context.SaveChanges();
    }
    
    public void Remove(int id)
    {
        if (!IsAuthenticated) return;
        var item = context.FavoriteItems.Find(_userId, id);
        if (item == null) return;
        
        context.FavoriteItems.Remove(item);
        context.SaveChanges();
    }
    
    public void Clear()
    {
        if (!IsAuthenticated) return;
        
        User.FavoriteItems.Clear();
        context.SaveChanges();
    }
    
    public int GetCount()
    {
        if (!IsAuthenticated) return 0;
        
        return UserWithFavoriteItems.FavoriteItems.Count;
    }
}