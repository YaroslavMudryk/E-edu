using Eedu.Data.Auditable;

namespace Eedu.Data.Entities.Groups;

public class GroupPost : VersionableBaseModel<Guid>, ITenantEntity
{
    public Guid GroupId { get; set; }
    public Group Group { get; set; }
    public Guid PostId { get; set; }
    public Post Post { get; set; }
    public string TenantId { get; set; }
}
