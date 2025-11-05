using Eedu.Data.Auditable;

namespace Eedu.Data.Entities.Dormitory;

public class FurnitureItem : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Name { get; set; } // e.g., "Bed", "Desk", "Chair", "Wardrobe"
    public string Description { get; set; }
    public string SerialNumber { get; set; }
    public string Condition { get; set; } // e.g., "New", "Good", "Fair", "Poor"
    public DateTime? PurchaseDate { get; set; }
    public decimal? PurchasePrice { get; set; }
    public bool IsAvailable { get; set; }
    
    public Guid RoomId { get; set; }
    public Room Room { get; set; }
    
    public string TenantId { get; set; }
}

