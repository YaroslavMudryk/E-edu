using Eedu.Data.ValueObjects;

namespace Eedu.Data.Entities.Identity;

public class FailedLoginAttempt : BaseModel<Guid>
{
    public string Login { get; set; }
    public string Password { get; set; }
    public AppInfo Client { get; set; }
    public LocationInfo Location { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}
