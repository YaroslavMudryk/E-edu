namespace Eedu.Data.Entities.Identity;

public class Permission : BaseModel<Guid>
{
    public string Value { get; set; }
    public string DisplayName { get; set; }
}
