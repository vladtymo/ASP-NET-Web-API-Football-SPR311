using System.ComponentModel.DataAnnotations;

namespace Core.Dtos;

public class CreateTeamModel
{
    //[Required]
    public string Logo { get; set; }
    public string Name { get; set; }
    //[RegularExpression(@"^[A-Z][\w\s]+$")]
    public string Country { get; set; }
}