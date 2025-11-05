using Eedu.Data.Auditable;

namespace Eedu.Data.Entities.Groups;

public class GroupInvite : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public bool IsActive { get; set; }
    public DateTime? ActiveFrom { get; set; }
    public DateTime? ActiveTo { get; set; }
    public Guid GroupId { get; set; }
    public Group Group { get; set; }
    
    // TenantId should equal Group.Specialty.Faculty.UniversityId (set via relationship)
    public Guid TenantId { get; set; }
}
