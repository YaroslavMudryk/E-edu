namespace Eedu.Data.Entities.Identity;

public class MfaRecoveryCode : VersionableBaseModel<Guid>
{
    public string CodeHash { get; set; }
    public bool IsUsed { get; set; }
    public DateTime? UsedAt { get; set; }
    public DateTime ExpiryAt { get; set; }
    public Guid MfaId { get; set; }
    public Mfa Mfa { get; set; }
}
