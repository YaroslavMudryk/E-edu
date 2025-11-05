using Eedu.Data.Auditable;
using Eedu.Data.Enums;

namespace Eedu.Data.Entities.Dormitories;

public class MaintenanceRequest : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public MaintenanceStatus Status { get; set; }
    public string Priority { get; set; } // e.g., "Low", "Medium", "High", "Urgent"
    public DateTime RequestDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public string ResolutionNotes { get; set; }
    public decimal? Cost { get; set; }
    
    public Guid RoomId { get; set; }
    public Room Room { get; set; }
    
    public Guid RequestedById { get; set; } // Student/staff who requested
    public User RequestedBy { get; set; }
    
    public Guid? AssignedToId { get; set; } // Maintenance staff assigned to fix
    public User AssignedTo { get; set; }
    
    public string TenantId { get; set; }
}

