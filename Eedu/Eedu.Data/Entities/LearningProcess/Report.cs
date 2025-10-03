using Eedu.Data.Auditable;
using Eedu.Data.Enums;

namespace Eedu.Data.Entities.LearningProcess;

public class Report : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Title { get; set; }
    public bool IsDraft { get; set; }
    public ReportType Type { get; set; }
    public List<Student> CalculatedMarks { get; set; }
    public List<Student> Marks { get; set; }
    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; }
    public string TenantId { get; set; }
}

public class Student
{
    public Guid StudentId { get; set; }
    public string StudentName { get; set; }
    public int Mark { get; set; }
}
