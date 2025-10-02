using System.ComponentModel.DataAnnotations.Schema;

namespace Eedu.Data.Entities.Identity;

public class Ban : BaseModel<Guid>
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Cause { get; set; }
    [NotMapped]
    public bool IsPermanent => End == DateTime.MaxValue;
    public long UserId { get; set; }
    public User User { get; set; }
}
