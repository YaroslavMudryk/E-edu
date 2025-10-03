using Eedu.Data.Enums;

namespace Eedu.Data.Entities.Identity;

public class Contact : VersionableBaseModel<Guid>
{

    public string Title { get; set; }
    public string Value { get; set; }
    public ContactType Type { get; set; }
    public bool IsMain { get; set; }
    public bool IsConfirmed { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public bool CanBeDeleted { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}
