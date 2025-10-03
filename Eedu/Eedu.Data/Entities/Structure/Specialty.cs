using Eedu.Data.Auditable;
using Eedu.Data.Entities.Groups;

namespace Eedu.Data.Entities.Structure;

public class Specialty : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public Guid FacultyId { get; set; }
    public Faculty Faculty { get; set; }
    public ICollection<Group> Groups { get; set; } = [];
    public string TenantId { get; set; }
}
