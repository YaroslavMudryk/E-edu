using Eedu.Data.Auditable;

namespace Eedu.Data.Entities.Groups;

public class Post : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime AvailableAfter { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
    public ICollection<GroupPost> GroupPosts { get; set; } = [];
    public ICollection<PostComment> PostComments { get; set; } = [];
    
    // TenantId should equal GroupPost.Group.Specialty.Faculty.UniversityId (set via relationship)
    // Note: Post can belong to multiple groups, TenantId should be set from primary GroupPost
    public Guid TenantId { get; set; }
}
