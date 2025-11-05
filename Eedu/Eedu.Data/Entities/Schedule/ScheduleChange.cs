using Eedu.Data.Auditable;
using Eedu.Data.Enums;
using Eedu.Data.Entities;

namespace Eedu.Data.Entities.Schedule;

public class ScheduleChange : VersionableBaseModel<Guid>, ITenantEntity
{
    public DateTime ChangeDate { get; set; } // When the change applies
    public string Reason { get; set; } // Reason for change
    public string Notes { get; set; }
    
    // Changed values (if different from original schedule)
    public ScheduleDay? ChangedDayOfWeek { get; set; }
    public TimeOnly? ChangedStartTime { get; set; }
    public TimeOnly? ChangedEndTime { get; set; }
    public LessonType? ChangedLessonType { get; set; }
    public string? ChangedRoom { get; set; }
    public Guid? ChangedTeacherId { get; set; }
    public User? ChangedTeacher { get; set; }
    
    // Who made the change
    public Guid ChangedById { get; set; }
    public User ChangedBy { get; set; }
    
    // Reference to original schedule
    public Guid ScheduleId { get; set; }
    public Schedule Schedule { get; set; }
    
    public string TenantId { get; set; }
}

