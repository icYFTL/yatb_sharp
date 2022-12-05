using Microsoft.EntityFrameworkCore;
using yatb_sharp.Database.Models;

namespace yatb_sharp.Database;

public sealed class ApplicationContext : DbContext
{
    public DbSet<Country> Countries { get; init; }
    public DbSet<Role> Roles { get; init; }
    public DbSet<Permission> Permissions { get; init; }
    public DbSet<User> Users { get; init; }
    public DbSet<Exercise> Exercises { get; init; }
    
    private readonly IConfiguration _configuration;

    public ApplicationContext(IConfiguration configuration)
    {
        _configuration = configuration;
        Database!.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }

    protected void Initialize()
    {
        Permissions.Add(new Permission
        {
            Name = "AddTask"
        });
        Permissions.Add(new Permission
        {
            Name = "AddTask"
        });
        Roles.Add(new Role
        {
            Name = "User",
            Description = "Default user"
        });
        Roles.Add(new Role
        {
            Name = "Admin",
            Description = "Default administrator"
        });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(x => x.Uid);
            entity.Property(x => x.Uid).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(x => x.Affiliation).HasMaxLength(50);
            entity.Property(x => x.Score).HasDefaultValueSql("0");
        });
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(x => x.Uid);
            entity.Property(x => x.Uid).HasDefaultValueSql("uuid_generate_v4()");
        });
        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(x => x.Uid );
            entity.Property(x => x.Uid).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(x => x.Title).HasMaxLength(35);
            entity.Property(x => x.Body).HasMaxLength(255);
            entity.Property(x => x.Author).HasMaxLength(50);
            entity.Property(x => x.Flag).HasMaxLength(255);
            entity.Property(x => x.Hidden).HasDefaultValueSql("true");
            entity.Property(x => x.Dl).HasDefaultValueSql("false");
            entity.Property(x => x.AddedAt).HasDefaultValueSql("now()");
            entity.Property(x => x.EditedAt).HasDefaultValueSql("now()");
        });
        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(x => x.Uid);
            entity.Property(x => x.Uid).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(x => x.Name).HasMaxLength(100);
            entity.Property(x => x.Description).HasMaxLength(255);
        });
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(x => x.Uid);
            entity.Property(x => x.Uid).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(x => x.Name).HasMaxLength(100);
            entity.Property(x => x.Description).HasMaxLength(255);
        });
        modelBuilder.Entity<ScoringType>(entity =>
        {
            entity.HasKey(x => x.Uid);
            entity.Property(x => x.Uid).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(x => x.Name).HasMaxLength(100);
            entity.Property(x => x.Description).HasMaxLength(255);
        });
        modelBuilder.Entity<FlagType>(entity =>
        {
            entity.HasKey(x => x.Uid);
            entity.Property(x => x.Uid).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(x => x.Name).HasMaxLength(100);
            entity.Property(x => x.Description).HasMaxLength(255);
        });
        modelBuilder.Entity<TaskCategory>(entity =>
        {
            entity.HasKey(x => x.Uid);
            entity.Property(x => x.Uid).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(x => x.Name).HasMaxLength(100);
            entity.Property(x => x.Description).HasMaxLength(255);
        });
        modelBuilder.Entity<PermissionToRole>(entity =>
        {
            entity.HasKey(x => x.Uid);
            entity.Property(x => x.Uid).HasDefaultValueSql("uuid_generate_v4()");
        });
        modelBuilder.Entity<RoleToUser>(entity =>
        {
            entity.HasKey(x => x.Uid);
            entity.Property(x => x.Uid).HasDefaultValueSql("uuid_generate_v4()");
        });
        modelBuilder.Entity<TaskToUser>(entity =>
        {
            entity.HasKey(x => x.Uid);
            entity.Property(x => x.Uid).HasDefaultValueSql("uuid_generate_v4()");
        });
    }
}