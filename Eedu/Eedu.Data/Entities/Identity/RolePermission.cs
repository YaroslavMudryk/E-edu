namespace Eedu.Data.Entities.Identity;

public class RolePermission : BaseModel<Guid>
{
    public DateTime ActiveFrom { set; get; }
    public DateTime? ActiveTo { set; get; }
    public bool IsActive { get; set; }
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
    public Guid PermissionId { get; set; }
    public Permission Permission { get; set; }
}
