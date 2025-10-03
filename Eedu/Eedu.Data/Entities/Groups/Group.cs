using Eedu.Data.Auditable;
using Eedu.Data.Entities.Structure;

namespace Eedu.Data.Entities.Groups;

public class Group : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Name { get; set; }
    public byte NameIndexInceremnt { get; set; }
    public string Image { get; set; }

    public DateOnly Start { get; set; }
    public DateOnly End { get; set; }

    public Guid SpecialtyId { get; set; }
    public Specialty Specialty { get; set; }
    public ICollection<GroupInvite> GroupInvites { get; set; } = [];
    public ICollection<UserGroup> UserGroups { get; set; } = [];
    public ICollection<GroupPost> GroupPosts { get; set; } = [];
    public string TenantId { get; set; }
}
