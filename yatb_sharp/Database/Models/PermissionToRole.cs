using System.ComponentModel.DataAnnotations.Schema;

namespace yatb_sharp.Database.Models;

[Table("permission_to_role")]
public class PermissionToRole
{
    public Guid Uid { get; init; }

    public required Guid PermissionUid { get; init; }
    [ForeignKey("PermissionUid")] public Permission Permission { get; init; } = null!;

    public required Guid RoleUid { get; init; }
    [ForeignKey("RoleUid")] public Role Role { get; init; } = null!;
}