namespace Data.Models;

public class Team
{
    public int Id { get; set; }
    public string Logo { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }

    public ICollection<Player>? Players { get; set; }
    public ICollection<User>? InFavoriteUsers { get; set; }
}