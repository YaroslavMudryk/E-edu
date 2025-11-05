using Eedu.Data.Auditable;
using Eedu.Data.Enums;
using Eedu.Data.Entities;

namespace Eedu.Data.Entities.Dormitory;

public class RoomInspection : VersionableBaseModel<Guid>, ITenantEntity
{
    public DateTime InspectionDate { get; set; }
    public DateTime? ScheduledDate { get; set; }
    public InspectionStatus Status { get; set; }
    public string Notes { get; set; }
    public string Findings { get; set; } // JSON or text description of findings
    public int? Score { get; set; } // Optional scoring (e.g., 1-100)
    public bool RequiresFollowUp { get; set; }
    public DateTime? FollowUpDate { get; set; }
    
    public Guid RoomId { get; set; }
    public Room Room { get; set; }
    
    public Guid InspectedById { get; set; } // Staff member who performed inspection
    public User InspectedBy { get; set; }
    
    public string TenantId { get; set; }
}

