

using LibraryManagmentSystem.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentSystem.DataLayer.Context;

public class LibraryDbContext:DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}
