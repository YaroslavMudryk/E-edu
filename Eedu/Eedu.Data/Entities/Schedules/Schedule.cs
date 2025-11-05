using Eedu.Data.Auditable;
using Eedu.Data.Entities.Groups;
using Eedu.Data.Entities.LearningProcess;
using Eedu.Data.Enums;

namespace Eedu.Data.Entities.Schedules;

public class Schedule : VersionableBaseModel<Guid>, ITenantEntity
{
    public ScheduleDay DayOfWeek { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public ScheduleType Type { get; set; }
    public LessonType? LessonType { get; set; } // Optional: Type of lesson (Lecture, Laboratory, Practical, etc.)
    public string? Room { get; set; } // Room/classroom name or number
    public string? Notes { get; set; }
    public bool IsActive { get; set; }
    
    // Date range for this schedule entry (if temporary)
    public DateOnly? ValidFrom { get; set; }
    public DateOnly? ValidTo { get; set; }
    
    // Required: Group that has this schedule
    public Guid GroupId { get; set; }
    public Group Group { get; set; }
    
    // Optional: Subject (if linked to a subject)
    public Guid? SubjectId { get; set; }
    public Subject Subject { get; set; }
    
    // Optional: Specific lesson instance (if linked to a lesson)
    public Guid? LessonId { get; set; }
    public Lesson Lesson { get; set; }
    
    // Optional: Teacher (if different from Subject.Teacher or if no Subject)
    public Guid? TeacherId { get; set; }
    public User Teacher { get; set; }
    
    // Schedule period (semester/academic period)
    public Guid? SchedulePeriodId { get; set; }
    public SchedulePeriod SchedulePeriod { get; set; }
    
    // TenantId should equal Group.Specialty.Faculty.UniversityId (set via relationship)
    public Guid TenantId { get; set; }
}

