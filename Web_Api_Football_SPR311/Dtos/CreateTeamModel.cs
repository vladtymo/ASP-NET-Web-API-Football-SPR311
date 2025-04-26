using System.ComponentModel.DataAnnotations;

namespace Web_Api_Football_SPR311.Dtos;

public class CreateTeamModel
{
    //[Required]
    public string Logo { get; set; }
    public string Name { get; set; }
    //[RegularExpression(@"^[A-Z][\w\s]+$")]
    public string Country { get; set; }
}