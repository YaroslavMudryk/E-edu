using Eedu.Data.Auditable;
using Eedu.Data.Enums;

namespace Eedu.Data.Entities.Groups;

public class UserGroup : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Title { get; set; }
    public UserGroupStatus Status { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid GroupId { get; set; }
    public Group Group { get; set; }
    public Guid UserGroupRoleId { get; set; }
    public UserGroupRole UserGroupRole { get; set; }
    
    // TenantId should equal Group.Specialty.Faculty.UniversityId (set via relationship)
    public Guid TenantId { get; set; }
}
