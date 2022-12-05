using System.ComponentModel.DataAnnotations.Schema;

namespace yatb_sharp.Database.Models;

[Table("flag_type")]
public class FlagType
{
    public Guid Uid { get; init; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}