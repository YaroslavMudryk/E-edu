using Eedu.Data.Auditable;

namespace Eedu.Data.Entities.Dormitories;

public class RoomAmenity : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Name { get; set; } // e.g., "WiFi", "Air Conditioning", "Refrigerator"
    public string Description { get; set; }
    public bool IsAvailable { get; set; }
    
    public Guid RoomId { get; set; }
    public Room Room { get; set; }
    
    public string TenantId { get; set; }
}

