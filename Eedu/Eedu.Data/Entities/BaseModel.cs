using Eedu.Data.Auditable;

namespace Eedu.Data.Entities;

public class BaseModel
{
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }
    public string UpdatedBy { get; set; }
}

public class BaseModel<TId> : BaseModel
{
    public TId Id { get; set; }
}

public class SoftDeletableBaseModel<TId> : BaseModel<TId>, ISoftDeletable
{
    public DateTime? DeletedAt { get; set; }
    public string DeletedBy { get; set; }
}

public class VersionableBaseModel<TId> : BaseModel<TId>, IVersionable
{
    public int Version { get; set; }
}

public class SoftDeletableVersionableBaseModel<TId> : BaseModel<TId>, ISoftDeletable, IVersionable
{
    public DateTime? DeletedAt { get; set; }
    public string DeletedBy { get; set; }
    public int Version { get; set; }
}
