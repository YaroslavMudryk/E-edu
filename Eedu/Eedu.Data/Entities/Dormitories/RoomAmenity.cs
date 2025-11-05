using Eedu.Data.Auditable;

namespace Eedu.Data.Entities.Dormitories;

public class RoomAmenity : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Name { get; set; } // e.g., "WiFi", "Air Conditioning", "Refrigerator"
    public string Description { get; set; }
    public bool IsAvailable { get; set; }
    
    public Guid RoomId { get; set; }
    public Room Room { get; set; }
    
    // TenantId should equal Room.Dormitory.UniversityId (set via relationship)
    public Guid TenantId { get; set; }
}

