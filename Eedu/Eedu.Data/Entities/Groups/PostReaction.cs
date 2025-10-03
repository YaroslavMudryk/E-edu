using Eedu.Data.Auditable;

namespace Eedu.Data.Entities.Groups;

public class PostReaction : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Value { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid PostId { get; set; }
    public Post Post { get; set; }
    public string TenantId { get; set; }
}
