using Eedu.Data.Auditable;
using Eedu.Data.Entities.Groups;

namespace Eedu.Data.Entities.Schedules;

public class SchedulePeriod : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Name { get; set; } // e.g., "Fall 2024", "Spring 2025"
    public string Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsActive { get; set; }
    
    public Guid? GroupId { get; set; } // Optional: Can be group-specific
    public Group Group { get; set; }
    
    public ICollection<Schedule> Schedules { get; set; } = [];
    
    // TenantId should equal Group.Specialty.Faculty.UniversityId (set via relationship) or null if not group-specific
    public Guid TenantId { get; set; }
}

