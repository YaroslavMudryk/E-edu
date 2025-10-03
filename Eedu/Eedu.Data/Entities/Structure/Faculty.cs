using Eedu.Data.Auditable;

namespace Eedu.Data.Entities.Structure;

public class Faculty : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public Guid UniversityId { get; set; }
    public University University { get; set; }
    public ICollection<Specialty> Specialties { get; set; } = [];
    public string TenantId { get; set; }
}
