using Eedu.Data.Auditable;
using Eedu.Data.Enums;

namespace Eedu.Data.Entities.LearningProcess;

public class Lesson : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Theme { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public LessonType LessonType { get; set; }
    public InviteLink InviteLinks { get; set; }
    public List<UsefulLink> UsefulLinks { get; set; }
    public string Homework { get; set; }
    public Guid? PreviewLessonId { get; set; }
    public Guid? NextLessonId { get; set; }

    public ICollection<Mark> Marks { get; set; } = [];
    public Guid? SubstituteTeacherId { get; set; }
    public User SubstituteTeacher { get; set; }
    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; }
    public string TenantId { get; set; }
}

public class InviteLink
{
    public string ZoomLink { get; set; }
    public string MicrosoftTeamsLink { get; set; }
    public string GoogleMeetLink { get; set; }
    public string SkypeLink { get; set; }
    public string DiscordLink { get; set; }
}

public class UsefulLink
{
    public string Title { get; set; }
    public string Url { get; set; }
}
