using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class Player
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    
    [Range(0, int.MaxValue, ErrorMessage = "Goals cannot be negative.")]
    public int Goals { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Player number cannot be negative.")]
    public int Number { get; set; }
    public DateTime Birthdate { get; set; }
    
    [Required(ErrorMessage = "Player team is required.")]
    public int TeamId { get; set; }
    public Team? Team { get; set; }
}