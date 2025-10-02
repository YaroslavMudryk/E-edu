namespace Eedu.Data.Entities.Identity;

public class ClientPermission : VersionableBaseModel<Guid>
{
    public DateTime ActiveFrom { set; get; }
    public DateTime? ActiveTo { set; get; }
    public bool IsActive { get; set; }
    public Guid PermissionId { get; set; }
    public Permission Permission { get; set; }
    public int AppId { get; set; }
    public App App { get; set; }
}
