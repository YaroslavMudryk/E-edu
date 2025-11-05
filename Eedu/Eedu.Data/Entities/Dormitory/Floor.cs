using Eedu.Data.Auditable;

namespace Eedu.Data.Entities.Dormitory;

public class Floor : VersionableBaseModel<Guid>, ITenantEntity
{
    public int FloorNumber { get; set; }
    public string Name { get; set; } // e.g., "First Floor", "Ground Floor"
    public string Description { get; set; }
    public int Capacity { get; set; } // Total capacity in terms of beds
    
    public Guid DormitoryId { get; set; }
    public Dormitory Dormitory { get; set; }
    
    public ICollection<Room> Rooms { get; set; } = [];
    public string TenantId { get; set; }
}

