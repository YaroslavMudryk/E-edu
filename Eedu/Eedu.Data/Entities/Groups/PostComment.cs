using Eedu.Data.Auditable;

namespace Eedu.Data.Entities.Groups;

public class PostComment : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Text { get; set; }
    public Guid? ReplyCommentId { get; set; }
    public PostComment ReplyComment { get; set; }
    public bool AnonymousAuthor { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid PostId { get; set; }
    public Post Post { get; set; }
    
    // TenantId should equal Post.TenantId (set via relationship)
    public Guid TenantId { get; set; }
}
