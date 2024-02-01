

using LibraryManagmentSystem.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentSystem.DataLayer.Context;

public class LibraryDbContext:DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<RoleModule> RoleModules { get; set; }
    public DbSet<EnumState> States { get; set; }
    public LibraryDbContext( DbContextOptions<LibraryDbContext> options) : base(options) 
    { 
        
    }

    
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseLazyLoadingProxies();
    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EnumState>()
     .HasMany(e => e.Modules)
     .WithOne(m => m.State).HasForeignKey(s => s.StateId);
        modelBuilder.Entity<EnumState>()
            .HasMany(e => e.Users)
            .WithOne().HasForeignKey(s => s.StateId); // Assuming User class has a navigation property
//        modelBuilder.Entity<EnumState>().HasData(
// new EnumState { Id = 1, FullName = "", ShortName = "", CreateDate = default,IsDeleted = false },
// new EnumState { Id = 2,FullName = "", ShortName = "", CreateDate = default, IsDeleted = false }
 
//);
        modelBuilder.Entity<EnumState>()
            .HasMany(e => e.UserRoles)
            .WithOne().HasForeignKey(s => s.StateId); // Assuming UserRole class has a navigation property

        modelBuilder.Entity<EnumState>()
            .HasMany(e => e.Roles)
            .WithOne(r => r.State).HasForeignKey(s => s.StateId);

        modelBuilder.Entity<EnumState>()
            .HasMany(e => e.RoleModules)
            .WithOne(rm => rm.State).HasForeignKey(s => s.StateId);
        modelBuilder.Entity<UserRole>().HasKey(e => new { e.UserId, e.RoleId });
        modelBuilder.Entity<RoleModule>().HasKey(e => new { e.ModuleId, e.RoleId });
    }
}
