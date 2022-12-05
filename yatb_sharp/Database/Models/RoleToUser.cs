using System.ComponentModel.DataAnnotations.Schema;

namespace yatb_sharp.Database.Models;

[Table("role_to_user")]
public class RoleToUser
{
    public Guid Uid { get; init; }

    public required Guid RoleUid { get; init; }
    [ForeignKey("RoleUid")] public Role Role { get; init; } = null!;

    public required Guid UserUid { get; init; }
    [ForeignKey("UserUid")] public User User { get; init; } = null!;
}