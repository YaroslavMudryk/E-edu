using System.ComponentModel.DataAnnotations.Schema;

namespace Eedu.Data.Auditable;

public interface ISoftDeletable
{
    public DateTime? DeletedAt { get; set; }
    public string DeletedBy { get; set; }

    [NotMapped]
    public bool HardDelete { get; set; }

    public void MarkAsHardDeleted()
    {
        HardDelete = true;
    }
}
