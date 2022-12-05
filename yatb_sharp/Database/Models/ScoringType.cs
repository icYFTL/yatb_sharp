using System.ComponentModel.DataAnnotations.Schema;

namespace yatb_sharp.Database.Models;

[Table("scoring_types")]
public class ScoringType
{
    public Guid Uid { get; init; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}