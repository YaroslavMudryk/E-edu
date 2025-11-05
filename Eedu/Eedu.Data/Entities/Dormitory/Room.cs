using Eedu.Data.Auditable;
using Eedu.Data.Enums;

namespace Eedu.Data.Entities.Dormitory;

public class Room : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Number { get; set; } // Room number (e.g., "101", "2A-15")
    public RoomType Type { get; set; }
    public RoomStatus Status { get; set; }
    public int Capacity { get; set; } // Maximum number of occupants
    public int CurrentOccupancy { get; set; } // Current number of occupants
    public decimal Area { get; set; } // Room area in square meters
    public string Description { get; set; }
    public bool HasPrivateBathroom { get; set; }
    public bool HasKitchen { get; set; }
    public bool IsAccessible { get; set; } // For disabled access
    
    public Guid FloorId { get; set; }
    public Floor Floor { get; set; }
    
    public Guid DormitoryId { get; set; }
    public Dormitory Dormitory { get; set; }
    
    public ICollection<RoomAssignment> Assignments { get; set; } = [];
    public ICollection<RoomAmenity> Amenities { get; set; } = [];
    public ICollection<RoomInspection> Inspections { get; set; } = [];
    public ICollection<MaintenanceRequest> MaintenanceRequests { get; set; } = [];
    public ICollection<FurnitureItem> FurnitureItems { get; set; } = [];
    public string TenantId { get; set; }
}

