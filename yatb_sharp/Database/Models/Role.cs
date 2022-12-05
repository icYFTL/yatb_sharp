using System.ComponentModel.DataAnnotations.Schema;

namespace yatb_sharp.Database.Models;

[Table("roles")]
public class Role
{
    public Guid Uid { get; init; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    
    public List<Permission>? Permissions { get; init; }
}