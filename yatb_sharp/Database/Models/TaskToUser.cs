using System.ComponentModel.DataAnnotations.Schema;

namespace yatb_sharp.Database.Models;

[Table("task_to_user")]
public class TaskToUser
{
    public Guid Uid { get; init; }
    public required Guid TaskUid { get; init; }
    [ForeignKey("TaskUid")] public Exercise Exercise { get; init; } = null!;

    public required Guid UserUid { get; init; }
    [ForeignKey("UserUid")] public User User { get; init; } = null!;
    
    public DateTime SolvedAt { get; init; }
    public int SolvedScore { get; set; }
}