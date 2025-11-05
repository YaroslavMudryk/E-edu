using Eedu.Data.Auditable;
using Eedu.Data.Enums;

namespace Eedu.Data.Entities.Notifications;

public class NotificationDelivery : VersionableBaseModel<Guid>, ITenantEntity
{
    public NotificationChannel Channel { get; set; }
    public bool IsDelivered { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public bool IsRead { get; set; }
    public DateTime? ReadAt { get; set; }
    public string? DeliveryError { get; set; }
    public int RetryCount { get; set; }
    
    // Delivery metadata (JSON)
    public string? Metadata { get; set; } // Additional delivery info (email ID, push token, etc.)
    
    public Guid NotificationId { get; set; }
    public Notification Notification { get; set; }
    
    public string TenantId { get; set; }
}

