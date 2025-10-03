using Eedu.Data.Enums;
using Eedu.Data.ValueObjects;

namespace Eedu.Data.Entities.Identity;

public class Session : VersionableBaseModel<Guid>
{
    public AppInfo App { get; set; }
    public LocationInfo Location { set; get; }
    public ClientInfo Client { set; get; }
    public SessionType Type { get; set; }
    public bool ViaMfa { get; set; }
    public SessionStatus Status { set; get; }
    public string VerificationId { get; set; }
    public DateTime? VerificationExpire { get; set; }
    public Guid? AuthorizedBy { get; set; }
    public string Language { set; get; }
    public Guid? DeactivatedBySessionId { set; get; }
    public DateTime? DeactivatedAt { set; get; }
    public DateTime ExpireAt { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid? DeviceId { get; set; }
    public Device Device { get; set; }
    public Guid? QrId { get; set; }
    public Qr Qr { get; set; }
    public Dictionary<string, string> Data { get; set; }
    public List<RefreshToken> Tokens { get; set; } = [];
}
