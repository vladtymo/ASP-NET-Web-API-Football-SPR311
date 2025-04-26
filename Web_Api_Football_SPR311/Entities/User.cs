using Microsoft.AspNetCore.Identity;

namespace Web_Api_Football_SPR311.Models;

public class User : IdentityUser
{
   // add custom properties
   public DateTime Birthdate { get; set; }
   public ICollection<FavoriteItem> FavoriteItems { get; set; }
}