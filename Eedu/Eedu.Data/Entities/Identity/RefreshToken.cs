namespace Eedu.Data.Entities.Identity;

public class RefreshToken : VersionableBaseModel<Guid>
{
    public string Value { get; set; }
    public DateTime? UsedAt { set; get; }
    public DateTime ExpiredAt { set; get; }
    public Guid SessionId { get; set; }
    public Session Session { get; set; }
}
