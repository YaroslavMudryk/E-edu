using Eedu.Data.Enums;

namespace Eedu.Data.Entities.Identity;

public class Mfa : VersionableBaseModel<Guid>
{
    public DateTime? Activated { get; set; }
    public Guid? ActivatedBySessionId { get; set; }
    public string Secret { get; set; }
    public MfaType Type { get; set; }
    public DateTime? DiactivedAt { get; set; }
    public Guid? DiactivedBySessionId { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public List<MfaRecoveryCode> RecoveryCodes { get; set; } = [];
}
