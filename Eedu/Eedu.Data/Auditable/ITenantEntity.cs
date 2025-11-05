namespace Eedu.Data.Auditable;

/// <summary>
/// Entity that belongs to a specific tenant (university).
/// TenantId should equal UniversityId for tenant-specific entities.
/// </summary>
public interface ITenantEntity
{
    /// <summary>
    /// Tenant identifier (UniversityId).
    /// For tenant-specific entities, this should equal the UniversityId.
    /// For unified entities (like notifications), this tracks the tenant context.
    /// </summary>
    public Guid TenantId { get; set; }
}

