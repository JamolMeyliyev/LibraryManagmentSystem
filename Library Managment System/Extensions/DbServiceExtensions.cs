using LibraryManagmentSystem.DataLayer.Context;
using Microsoft.EntityFrameworkCore;


namespace Library_Managment_System.Extensions;

public static class DbServiceExtentions
{
    public static IServiceCollection AddDbContexts(
    this IServiceCollection service,
    IConfiguration configuration)
    {

        service.AddDbContext<LibraryDbContext>(options =>
        
        options.UseNpgsql("Host =localhost;Port=5432;Username=postgres;Password=postgres;Database = lms"));

        return service;
    }
}
