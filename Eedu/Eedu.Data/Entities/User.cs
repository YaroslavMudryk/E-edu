using Eedu.Data.Entities.Groups;
using Eedu.Data.Entities.Identity;
using Eedu.Data.Entities.LearningProcess;

namespace Eedu.Data.Entities;

public class User : SoftDeletableVersionableBaseModel<Guid>
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string PublicId { get; set; }

    public string Login { get; set; }
    public string PasswordHash { get; set; }


    public ICollection<Ban> Bans { get; set; } = [];
    public ICollection<Password> Passwords { get; set; } = [];
    public ICollection<Contact> Contacts { get; set; } = [];
    public ICollection<UserLogin> UserLogins { get; set; } = [];
    public ICollection<Session> Sessions { get; set; } = [];
    public ICollection<Device> Devices { get; set; } = [];
    public ICollection<Qr> Qrs { get; set; } = [];
    public ICollection<Mfa> Mfas { get; set; } = [];
    public ICollection<FailedLoginAttempt> FailedLoginAttempts { get; set; } = [];
    public ICollection<UserGroup> UserGroups { get; set; } = [];
    public ICollection<PostReaction> PostReactions { get; set; } = [];
    public ICollection<Post> Posts { get; set; } = [];
    public ICollection<PostComment> PostComments { get; set; } = [];
    public ICollection<Subject> Subjects { get; set; } = [];
}
