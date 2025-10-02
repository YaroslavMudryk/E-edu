﻿namespace Eedu.Data.Auditable;

public interface ISoftDeletable
{
    public DateTime? DeletedAt { get; set; }
    public string DeletedBy { get; set; }
}
