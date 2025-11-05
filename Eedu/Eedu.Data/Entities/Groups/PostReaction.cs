using Eedu.Data.Auditable;

namespace Eedu.Data.Entities.Groups;

public class PostReaction : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Value { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid PostId { get; set; }
    public Post Post { get; set; }
    
    // TenantId should equal Post.TenantId (set via relationship)
    public Guid TenantId { get; set; }
}
