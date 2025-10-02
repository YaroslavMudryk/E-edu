namespace Eedu.Data.Entities.Identity;

public class Role : VersionableBaseModel<Guid>
{
    public string Name { get; set; }
    public bool IsDefault { get; set; }
    public string NameNormalized { get; set; }
    public List<UserRole> UserRoles { get; set; } = [];
    public List<RolePermission> RoleClaims { get; set; } = [];
}
