using Eedu.Data.Entities;
using Eedu.Data.Entities.Dormitories;
using Eedu.Data.Entities.Groups;
using Eedu.Data.Entities.Identity;
using Eedu.Data.Entities.LearningProcess;
using Eedu.Data.Entities.Notifications;
using Eedu.Data.Entities.Schedules;
using Eedu.Data.Entities.Structure;
using Eedu.Data.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Eedu.Data.Ef.Context;

public class EduDbContext(DbContextOptions<EduDbContext> options) : DbContext(options)
{
    public DbSet<Audit> Audits { get; set; }
    public DbSet<Translation> Translations { get; set; }

    public DbSet<User> Users { get; set; }

    //identity
    public DbSet<Ban> Bans { get; set; }
    public DbSet<Password> Passwords { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<UserLogin> UserLogins { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<Qr> Qrs { get; set; }
    public DbSet<FailedLoginAttempt> FailedLoginAttempts { get; set; }
    public DbSet<Mfa> Mfas { get; set; }
    public DbSet<MfaRecoveryCode> MfaRecoveryCodes { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<ClientPermission> ClientPermissions { get; set; }
    public DbSet<App> Apps { get; set; }

    //structure
    public DbSet<University> Universities { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Specialty> Specialties { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupInvite> GroupInvites { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<UserGroupRole> UserGroupRoles { get; set; }
    public DbSet<GroupPost> GroupPosts { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostComment> PostComments { get; set; }
    public DbSet<PostReaction> PostReactions { get; set; }

    //learningprocess
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Mark> Marks { get; set; }
    public DbSet<Report> Reports { get; set; }

    //dormitory
    public DbSet<Dormitory> Dormitories { get; set; }
    public DbSet<Floor> Floors { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomAssignment> RoomAssignments { get; set; }
    public DbSet<RoomAmenity> RoomAmenities { get; set; }
    public DbSet<RoomInspection> RoomInspections { get; set; }
    public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
    public DbSet<RoomFee> RoomFees { get; set; }
    public DbSet<FurnitureItem> FurnitureItems { get; set; }

    //schedule
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<SchedulePeriod> SchedulePeriods { get; set; }

    //notifications
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<NotificationDelivery> NotificationDeliveries { get; set; }
    public DbSet<NotificationTemplate> NotificationTemplates { get; set; }
    public DbSet<UserNotificationSettings> UserNotificationSettings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //basic
        modelBuilder.Entity<Audit>(builder =>
        {
            builder.HasKey(a => a.Id);
            builder.OwnsMany(s => s.Changes, builder =>
            {
                builder.ToJson();
            });
        });
        modelBuilder.Entity<Translation>(builder =>
        {
            builder.HasKey(e => e.Id);
        });
        modelBuilder.Entity<User>(builder =>
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(s => s.Login).IsUnique();
            builder.HasIndex(s => s.PublicId).IsUnique();
        });

        //identity
        modelBuilder.Entity<App>(builder =>
        {
            builder.HasKey(e => e.Id);
        });
        modelBuilder.Entity<Ban>(builder =>
        {
            builder.HasKey(e => e.Id);
        });
        modelBuilder.Entity<ClientPermission>(builder =>
        {
            builder.HasKey(e => e.Id);
        });
        modelBuilder.Entity<Contact>(builder =>
        {
            builder.HasKey(e => e.Id);
        });
        modelBuilder.Entity<Device>(builder =>
        {
            builder.HasKey(e => e.Id);
        });
        modelBuilder.Entity<FailedLoginAttempt>(builder =>
        {
            builder.HasKey(fla => fla.Id);
            builder.Property(s => s.Location).HasConversion(
                v => v.ToJson(),
                v => v.FromJson<LocationInfo>());

            builder.Property(s => s.Client).HasConversion(
                v => v.ToJson(),
                v => v.FromJson<AppInfo>());
        });
        modelBuilder.Entity<Mfa>(builder =>
        {
            builder.HasKey(e => e.Id);
        });
        modelBuilder.Entity<MfaRecoveryCode>(builder =>
        {
            builder.HasKey(e => e.Id);
        });
        modelBuilder.Entity<Password>(builder =>
        {
            builder.HasKey(e => e.Id);
        });
        modelBuilder.Entity<Permission>(builder =>
        {
            builder.HasKey(e => e.Id);
        });
        modelBuilder.Entity<Qr>(builder =>
        {
            builder.HasKey(q => q.Id);
            builder.HasOne(s => s.Session).WithOne(s => s.Qr)
                    .HasForeignKey<Qr>(s => s.SessionId);
        });
        modelBuilder.Entity<RefreshToken>(builder =>
        {
            builder.HasKey(e => e.Id);
        });
        modelBuilder.Entity<Role>(builder =>
        {
            builder.HasKey(e => e.Id);
        });
        modelBuilder.Entity<RolePermission>(builder =>
        {
            builder.HasKey(e => e.Id);
        });
        modelBuilder.Entity<Session>(builder =>
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.App).HasConversion(
                v => v.ToJson(),
                v => v.FromJson<AppInfo>());

            builder.Property(s => s.Location).HasConversion(
                v => v.ToJson(),
                v => v.FromJson<LocationInfo>());

            builder.Property(s => s.Client).HasConversion(
                v => v.ToJson(),
                v => v.FromJson<ClientInfo>());

            builder.Property(s => s.Data).HasConversion(
                v => v.ToJson(),
                v => v.FromJson<Dictionary<string, string>>());
        });
        modelBuilder.Entity<UserLogin>(builder =>
        {
            builder.HasKey(e => e.Id);
        });
        modelBuilder.Entity<UserRole>(builder =>
        {
            builder.HasKey(e => e.Id);
        });

        //structure
        modelBuilder.Entity<University>(e =>
        {
            e.HasKey(e => e.Id);
        });
        modelBuilder.Entity<Faculty>(e =>
        {
            e.HasKey(e => e.Id);
        });
        modelBuilder.Entity<Specialty>(e =>
        {
            e.HasKey(e => e.Id);
        });
        modelBuilder.Entity<Group>(e =>
        {
            e.HasKey(e => e.Id);
        });
        modelBuilder.Entity<GroupInvite>(e =>
        {
            e.HasKey(e => e.Id);
        });
        modelBuilder.Entity<UserGroup>(e =>
        {
            e.HasKey(e => e.Id);
        });
        modelBuilder.Entity<UserGroupRole>(e =>
        {
            e.HasKey(e => e.Id);
            e.Property(s => s.Permissions).HasConversion(
                v => v.ToJson(),
                v => v.FromJson<GroupRolePermissions>());
        });
        modelBuilder.Entity<GroupPost>(e =>
        {
            e.HasKey(e => e.Id);
        });
        modelBuilder.Entity<Post>(e =>
        {
            e.HasKey(e => e.Id);
        });
        modelBuilder.Entity<PostComment>(e =>
        {
            e.HasKey(e => e.Id);
        });
        modelBuilder.Entity<PostReaction>(e =>
        {
            e.HasKey(e => e.Id);
        });

        //learningprocess
        modelBuilder.Entity<Subject>(e =>
        {
            e.HasKey(e => e.Id);
            e.Property(s => s.Plan).HasConversion(
                v => v.ToJson(),
                v => v.FromJson<SubjectPlan>());
        });
        modelBuilder.Entity<Lesson>(e =>
        {
            e.HasKey(e => e.Id);
            e.Property(s => s.InviteLinks).HasConversion(
                v => v.ToJson(),
                v => v.FromJson<InviteLink>());
            e.Property(s => s.UsefulLinks).HasConversion(
                v => v.ToJson(),
                v => v.FromJson<List<UsefulLink>>());
        });
        modelBuilder.Entity<Mark>(e =>
        {
            e.HasKey(e => e.Id);
        });
        modelBuilder.Entity<Report>(e =>
        {
            e.HasKey(e => e.Id);
            e.Property(s => s.Marks).HasConversion(
                v => v.ToJson(),
                v => v.FromJson<List<Student>>());
            e.Property(s => s.CalculatedMarks).HasConversion(
                v => v.ToJson(), 
                v => v.FromJson<List<Student>>());
        });

        //dormitory
        modelBuilder.Entity<Dormitory>(e =>
        {
            e.HasKey(e => e.Id);
            e.HasIndex(d => new { d.UniversityId, d.Name }).IsUnique();
        });
        modelBuilder.Entity<Floor>(e =>
        {
            e.HasKey(e => e.Id);
            e.HasIndex(f => new { f.DormitoryId, f.FloorNumber }).IsUnique();
        });
        modelBuilder.Entity<Room>(e =>
        {
            e.HasKey(e => e.Id);
            e.HasIndex(r => new { r.FloorId, r.Number }).IsUnique();
        });
        modelBuilder.Entity<RoomAssignment>(e =>
        {
            e.HasKey(e => e.Id);
            e.HasIndex(ra => new { ra.UserId, ra.RoomId, ra.StartDate })
                .IsUnique()
                .HasFilter("[Status] IN (1, 2, 5)"); // Prevent duplicate active assignments
            
            // Configure multiple navigation properties to User
            e.HasOne(ra => ra.User)
                .WithMany(u => u.RoomAssignments)
                .HasForeignKey(ra => ra.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            e.HasOne(ra => ra.AssignedBy)
                .WithMany(u => u.AssignedRoomAssignments)
                .HasForeignKey(ra => ra.AssignedById)
                .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<RoomAmenity>(e =>
        {
            e.HasKey(e => e.Id);
        });
        modelBuilder.Entity<RoomInspection>(e =>
        {
            e.HasKey(e => e.Id);
            e.HasOne(ri => ri.InspectedBy)
                .WithMany(u => u.RoomInspections)
                .HasForeignKey(ri => ri.InspectedById)
                .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<MaintenanceRequest>(e =>
        {
            e.HasKey(e => e.Id);
            e.HasOne(mr => mr.RequestedBy)
                .WithMany(u => u.MaintenanceRequests)
                .HasForeignKey(mr => mr.RequestedById)
                .OnDelete(DeleteBehavior.Restrict);
            
            e.HasOne(mr => mr.AssignedTo)
                .WithMany(u => u.AssignedMaintenanceRequests)
                .HasForeignKey(mr => mr.AssignedToId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<RoomFee>(e =>
        {
            e.HasKey(e => e.Id);
            e.HasOne(rf => rf.ProcessedBy)
                .WithMany(u => u.ProcessedRoomFees)
                .HasForeignKey(rf => rf.ProcessedById)
                .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<FurnitureItem>(e =>
        {
            e.HasKey(e => e.Id);
            e.HasIndex(f => f.SerialNumber).IsUnique()
                .HasFilter("[SerialNumber] IS NOT NULL AND [SerialNumber] != ''");
        });

        //schedule
        modelBuilder.Entity<Schedule>(e =>
        {
            e.HasKey(e => e.Id);
            e.HasIndex(s => new { s.GroupId, s.DayOfWeek, s.StartTime, s.SchedulePeriodId })
                .IsUnique()
                .HasFilter("[IsActive] = 1 AND [Type] = 1"); // Prevent duplicate active regular schedules
            
            // Configure optional relationships
            e.HasOne(s => s.Teacher)
                .WithMany(u => u.Schedules)
                .HasForeignKey(s => s.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<SchedulePeriod>(e =>
        {
            e.HasKey(e => e.Id);
            e.HasIndex(sp => new { sp.GroupId, sp.Name }).IsUnique()
                .HasFilter("[GroupId] IS NOT NULL");
        });

        //notifications
        modelBuilder.Entity<Notification>(e =>
        {
            e.HasKey(e => e.Id);
            e.HasIndex(n => new { n.RecipientId, n.Status, n.CreatedAt })
                .HasFilter("[Status] IN (1, 2)"); // Index for unread/read notifications
            
            e.HasOne(n => n.Recipient)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);
            
            e.HasOne(n => n.Sender)
                .WithMany()
                .HasForeignKey(n => n.SenderId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<NotificationDelivery>(e =>
        {
            e.HasKey(e => e.Id);
            e.HasIndex(nd => new { nd.NotificationId, nd.Channel });
            
            e.HasOne(nd => nd.Notification)
                .WithMany(n => n.Deliveries)
                .HasForeignKey(nd => nd.NotificationId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<NotificationTemplate>(e =>
        {
            e.HasKey(e => e.Id);
            e.HasIndex(nt => new { nt.Type, nt.TenantId, nt.Name }).IsUnique();
        });
        modelBuilder.Entity<UserNotificationSettings>(e =>
        {
            e.HasKey(e => e.Id);
            e.HasIndex(uns => uns.UserId).IsUnique();
            
            e.HasOne(uns => uns.User)
                .WithOne(u => u.NotificationSettings)
                .HasForeignKey<UserNotificationSettings>(uns => uns.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}

public static class JsonExtensions
{
    private static readonly JsonSerializerOptions EntityFramework = new()
    {
        WriteIndented = false,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public static string ToJson(this object obj)
    {
        return JsonSerializer.Serialize(obj, EntityFramework);
    }

    public static T FromJson<T>(this string content)
    {
        return JsonSerializer.Deserialize<T>(content, EntityFramework)!;
    }
}
