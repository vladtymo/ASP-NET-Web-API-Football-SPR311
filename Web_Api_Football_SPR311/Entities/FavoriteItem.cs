using Microsoft.AspNetCore.Identity;

namespace Web_Api_Football_SPR311.Models;

public class FavoriteItem
{
    //public int Id { get; set; }
    
    // Composite Primary Key
    public string UserId { get; set; } 
    public User? User { get; set; }
    public int TeamId { get; set; } 
    public Team? Team { get; set; }
}