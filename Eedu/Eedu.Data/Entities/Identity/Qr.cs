namespace Eedu.Data.Entities.Identity;

public class Qr : VersionableBaseModel<Guid>
{
    public DateTime ActiveFrom { get; set; }
    public DateTime ActiveTo { get; set; }
    public DateTime ActivatedAt { get; set; }
    public string QrCodeVerify { get; set; }
    public string Ip { get; set; }
    public Guid SessionId { get; set; }
    public Session Session { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}
