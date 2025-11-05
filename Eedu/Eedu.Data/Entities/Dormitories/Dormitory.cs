using Eedu.Data.Auditable;
using Eedu.Data.Entities.Structure;

namespace Eedu.Data.Entities.Dormitories;

public class Dormitory : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public int Capacity { get; set; } // Total capacity in terms of beds
    public string ContactPhone { get; set; }
    public string ContactEmail { get; set; }
    public bool IsActive { get; set; }
    
    public Guid UniversityId { get; set; }
    public University University { get; set; }
    
    public ICollection<Floor> Floors { get; set; } = [];
    public ICollection<Room> Rooms { get; set; } = [];
    public string TenantId { get; set; }
}

