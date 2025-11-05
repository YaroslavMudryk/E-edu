using Eedu.Data.Auditable;
using Eedu.Data.Enums;
using Eedu.Data.Entities;

namespace Eedu.Data.Entities.Dormitory;

public class RoomFee : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Description { get; set; } // e.g., "Monthly Rent", "Utilities", "Deposit"
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? PaidDate { get; set; }
    public PaymentStatus Status { get; set; }
    public string PaymentMethod { get; set; } // e.g., "Cash", "Bank Transfer", "Credit Card"
    public string TransactionReference { get; set; }
    public string Notes { get; set; }
    
    public Guid RoomAssignmentId { get; set; }
    public RoomAssignment RoomAssignment { get; set; }
    
    public Guid? ProcessedById { get; set; } // Staff who processed payment
    public User ProcessedBy { get; set; }
    
    public string TenantId { get; set; }
}

