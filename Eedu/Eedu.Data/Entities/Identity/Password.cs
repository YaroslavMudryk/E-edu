namespace Eedu.Data.Entities.Identity;

public class Password : BaseModel<Guid>
{
    public string PasswordHash { set; get; }
    public string Hint { get; set; }
    public bool IsActive { get; set; }
    public DateTime ActivatedAt { get; set; }
    public DateTime? DeactivatedAt { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
