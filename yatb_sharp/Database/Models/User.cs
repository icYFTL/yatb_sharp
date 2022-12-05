using System.ComponentModel.DataAnnotations.Schema;

namespace yatb_sharp.Database.Models;

[Table("users")]
public class User
{
    public Guid Uid { get; init; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public int Score { get; set; }
    public string? Affiliation { get; set; }
    public Guid? CountryUid { get; set; }

    [ForeignKey("CountryUid")] public Country? Country { get; init; }
    public List<Role>? Roles { get; init; }
    
}