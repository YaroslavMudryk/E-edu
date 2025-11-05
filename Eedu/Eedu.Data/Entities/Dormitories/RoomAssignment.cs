using Eedu.Data.Auditable;
using Eedu.Data.Enums;

namespace Eedu.Data.Entities.Dormitories;

public class RoomAssignment : VersionableBaseModel<Guid>, ITenantEntity
{
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; } // Null if currently active
    public AssignmentStatus Status { get; set; }
    public string Notes { get; set; }
    public decimal MonthlyFee { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public Guid RoomId { get; set; }
    public Room Room { get; set; }
    
    public Guid? AssignedById { get; set; } // Admin/staff who assigned
    public User AssignedBy { get; set; }
    
    public ICollection<RoomFee> Fees { get; set; } = [];
    public string TenantId { get; set; }
}

