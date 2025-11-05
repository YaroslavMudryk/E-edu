using Eedu.Data.Auditable;
using Eedu.Data.Entities.Groups;
using Eedu.Data.Entities.LearningProcess;
using Eedu.Data.Enums;

namespace Eedu.Data.Entities.Notifications;

public class Notification : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Title { get; set; }
    public string Message { get; set; }
    public NotificationType Type { get; set; }
    public NotificationPriority Priority { get; set; }
    public NotificationStatus Status { get; set; }
    public DateTime? ReadAt { get; set; }
    public DateTime? ExpiresAt { get; set; }
    
    // Optional: Links to related entities
    public Guid? RelatedEntityId { get; set; } // Generic entity ID
    public string? RelatedEntityType { get; set; } // Entity type name (e.g., "Lesson", "Subject", "Group")
    
    // Optional: Specific entity links
    public Guid? SubjectId { get; set; }
    public Subject? Subject { get; set; }
    
    public Guid? LessonId { get; set; }
    public Lesson? Lesson { get; set; }
    
    public Guid? GroupId { get; set; }
    public Group? Group { get; set; }
    
    // Action data (JSON for flexible data storage)
    public string? ActionData { get; set; } // JSON data for action buttons, links, etc.
    public string? ActionUrl { get; set; } // Direct URL to related content
    
    // Recipient
    public Guid RecipientId { get; set; }
    public User Recipient { get; set; }
    
    // Optional: Sender (if notification is from a specific user)
    public Guid? SenderId { get; set; }
    public User? Sender { get; set; }
    
    // Delivery tracking
    public ICollection<NotificationDelivery> Deliveries { get; set; } = [];
    
    // TenantId: For unified notifications, can be derived from:
    // - Related entities (Subject, Lesson, Group) if linked
    // - User's primary university context if not linked to tenant-specific entity
    // - Can be unified/shared across universities but still tracks tenant context
    public Guid TenantId { get; set; }
}

