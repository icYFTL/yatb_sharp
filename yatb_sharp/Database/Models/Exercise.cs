using System.ComponentModel.DataAnnotations.Schema;

namespace yatb_sharp.Database.Models;

[Table("exercises")]
public class Exercise
{
    public Guid Uid { get; init; }
    public required string Title { get; set; }
    public required string Body { get; set; }
    public required int Score { get; set; }
    public required string Author { get; set; }
    public required string Flag { get; set; }
    public bool Hidden { get; set; } = true;
    public bool Dl { get; set; } = false;
    public DateTime AddedAt { get; init; } = DateTime.Now;
    public DateTime EditedAt { get; set; } = DateTime.Now;

    public required Guid AddedByUid { get; set; }
    [ForeignKey("AddedByUid")] public User AddedBy { get; init; } = null!;

    public required Guid EditedByUid { get; set; }
    [ForeignKey("EditedByUid")] public User EditedBy { get; init; } = null!;

    public required Guid ScoreTypeUid { get; set; }
    [ForeignKey("ScoreTypeUid")] public ScoringType ScoringType { get; init; } = null!;

    public required Guid FlagTypeUid { get; set; }
    [ForeignKey("FlagTypeUid")] public FlagType FlagType { get; init; } = null!;
}