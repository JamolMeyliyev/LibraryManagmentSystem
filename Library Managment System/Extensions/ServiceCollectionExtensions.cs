using edu.DataAccess.Repositories;
using LibraryManagmentSystem.DataLayer.Repositories;
using LibraryManagmentSystem.Integration.SMS;
using LibraryManagmentSystem.LogicLayer.Mapper;
using LibraryManagmentSystem.LogicLayer.Services;
using LibraryManagmentSystem.LogicLayer.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Library_Managment_System.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRoleModuleRepository, RoleModuleRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<IModuleRepository, ModuleRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserServive, UserService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IAccountService,AccountService>();
        services.AddScoped<IModuleService, ModuleService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ISmsService,SmsService>();
        services.AddMemoryCache();





        services.AddAutoMapper(typeof(CreateModuleToModuleMapper));
        services.AddAutoMapper(typeof(ModuleToRetunModuleModel));
        
        services.AddAutoMapper(typeof(UpdateModuleToModuleMapper));
        services.AddAutoMapper(typeof(CreateRoleModelToRoleMapper));
        services.AddAutoMapper(typeof(RoleToReturnRoleModelMapper));
        
        services.AddAutoMapper(typeof(UpdateRoleModelToRoleMapper));
        services.AddAutoMapper(typeof(CreateUserToUserMapper));


        return services;
    }
}
