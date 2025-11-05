using Eedu.Data.Auditable;

namespace Eedu.Data.Entities.Notifications;

public class UserNotificationSettings : VersionableBaseModel<Guid>, ITenantEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    // Channel preferences
    public bool InAppEnabled { get; set; } = true;
    public bool EmailEnabled { get; set; } = true;
    public bool PushEnabled { get; set; } = false;
    public bool SmsEnabled { get; set; } = false;
    
    // Type-specific preferences (JSON)
    public string? TypePreferences { get; set; } // JSON: { "GradePosted": { "InApp": true, "Email": true }, ... }
    
    // Quiet hours (times when notifications should be suppressed)
    public TimeOnly? QuietHoursStart { get; set; }
    public TimeOnly? QuietHoursEnd { get; set; }
    public bool QuietHoursEnabled { get; set; } = false;
    
    // Priority preferences
    public bool LowPriorityEnabled { get; set; } = true;
    public bool NormalPriorityEnabled { get; set; } = true;
    public bool HighPriorityEnabled { get; set; } = true;
    public bool UrgentPriorityEnabled { get; set; } = true;
    
    // Digest preferences
    public bool DigestEnabled { get; set; } = false;
    public string? DigestFrequency { get; set; } // "Daily", "Weekly", "Never"
    public TimeOnly? DigestTime { get; set; }
    
    public string TenantId { get; set; }
}

