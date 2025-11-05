using Eedu.Data.Auditable;
using Eedu.Data.Enums;

namespace Eedu.Data.Entities.Notifications;

public class NotificationTemplate : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public NotificationType Type { get; set; }
    public NotificationPriority DefaultPriority { get; set; }
    
    // Template content
    public string TitleTemplate { get; set; } // Supports placeholders like {UserName}, {SubjectName}
    public string MessageTemplate { get; set; } // Supports placeholders
    public string? SubjectTemplate { get; set; } // For email notifications
    
    // Enabled channels
    public bool InAppEnabled { get; set; } = true;
    public bool EmailEnabled { get; set; } = false;
    public bool PushEnabled { get; set; } = false;
    public bool SmsEnabled { get; set; } = false;
    
    // Template metadata
    public bool IsActive { get; set; }
    public string? Placeholders { get; set; } // JSON array of available placeholders
    
    public string TenantId { get; set; }
}

