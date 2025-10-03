using Eedu.Data.Auditable;

namespace Eedu.Data.Entities.LearningProcess;

public class Mark : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Value { get; set; }
    public bool Present { get; set; }
    public Guid LessonId { get; set; }
    public Lesson Lesson { get; set; }
    public Guid StudentId { get; set; }
    public User Student { get; set; }
    public string StudentName { get; set; } //format (LastName FirstName (if same names exists, appear MiddleName))
    public ICollection<Report> Reports { get; set; }
    public string TenantId { get; set; }
}
