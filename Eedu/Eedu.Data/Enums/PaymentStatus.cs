namespace Eedu.Data.Enums;

public enum PaymentStatus
{
    Pending = 1,      // Payment is pending
    Paid = 2,         // Payment is completed
    Overdue = 3,      // Payment is overdue
    Cancelled = 4,    // Payment was cancelled
    Refunded = 5      // Payment was refunded
}

