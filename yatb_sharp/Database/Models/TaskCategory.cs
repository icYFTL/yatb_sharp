using System.ComponentModel.DataAnnotations.Schema;

namespace yatb_sharp.Database.Models;

[Table("task_categories")]
public class TaskCategory
{
    public Guid Uid { get; init; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}