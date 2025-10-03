using Eedu.Data.Auditable;

namespace Eedu.Data.Entities.Groups;

public class UserGroupRole : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Name { get; set; }
    public GroupRolePermissions Permissions { get; set; }
    public ICollection<UserGroup> UserGroups { get; set; } = [];
    public string TenantId { get; set; }
}

public class GroupRolePermissions
{

}
