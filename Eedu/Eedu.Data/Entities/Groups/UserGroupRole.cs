using Eedu.Data.Auditable;

namespace Eedu.Data.Entities.Groups;

public class UserGroupRole : VersionableBaseModel<Guid>, ITenantEntity
{
    public string Name { get; set; }
    public GroupRolePermissions Permissions { get; set; }
    public ICollection<UserGroup> UserGroups { get; set; } = [];
    public string TenantId { get; set; }
}

public class GroupRolePermissions
{
    public bool CanCreatePost { get; set; }
    public bool CanUpdatePost { get; set; }
    public bool CanUpdateAllPosts { get; set; }
    public bool CanRemovePost { get; set; }
    public bool CanRemoveAllPosts { get; set; }

    public bool CanCreateComment { get; set; }
    public bool CanOpenCloseComment { get; set; }
    public bool CanRemoveComment { get; set; }
    public bool CanRemoveAllComments { get; set; }

    public bool CanCreateInviteCode { get; set; }
    public bool CanUpdateInviteCode { get; set; }
    public bool CanRemoveInviteCode { get; set; }
    public bool CanViewInviteCodes { get; set; }


    public bool CanUpdateImage { get; set; }
    public bool CanEditInfo { get; set; }
}
