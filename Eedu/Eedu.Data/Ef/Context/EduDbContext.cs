using Eedu.Data.Entities;
using Eedu.Data.Entities.Identity;
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
