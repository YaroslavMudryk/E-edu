using Eedu.Data.Auditable;
using Eedu.Data.Entities.Groups;

namespace Eedu.Data.Entities.LearningProcess;

public class Subject : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsTemplate { get; set; }
    public int RecommendedCourse { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public SubjectPlan Plan { get; set; }

    public Guid? GroupId { get; set; }
    public Group Group { get; set; }
    public Guid TeacherId { get; set; }
    public User Teacher { get; set; }
    public ICollection<Lesson> Lessons { get; set; } = [];
    public string TenantId { get; set; }
}

public class SubjectPlan
{
    public double MaxMarkPerLesson { get; set; }
    public double MinMarkPerLesson { get; set; }
    public bool WithExam { get; set; }
    public double MaxMark { get; set; }
    public double MaxMarkUpToExam { get; set; }
    public double MaxMarkInExam { get; set; }
    public int CommonHours { get; set; }
    public int LectureHours { get; set; }
    public int PracticHours { get; set; }
    public int LabsHours { get; set; }
    public int IndividualHours { get; set; }
    public int ExamHours { get; set; }
    public int OffsetHours { get; set; }
}
