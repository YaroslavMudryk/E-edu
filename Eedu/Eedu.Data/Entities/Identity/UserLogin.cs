namespace Eedu.Data.Entities.Identity;

public class UserLogin : VersionableBaseModel<Guid>
{
    public string Provider { get; set; }
    public string ProviderUserId { get; set; }
    public string Token { get; set; }
    public DateTime? TokenExpireAt { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
