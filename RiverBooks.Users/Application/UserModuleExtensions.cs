using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiverBooks.Users.Data;
using RiverBooks.Users.UseCases;
using Serilog;

namespace RiverBooks.Users.Application;

public static class UserModuleExtensions
{
  public static IServiceCollection AddUserModuleServices(this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger, List<Assembly> mediatRAssemblies)
  {
    var connectionString = config.GetConnectionString("UsersConnectionString");

    services.AddDbContext<UsersDbContext>(options =>
      options.UseSqlServer(connectionString));

    services.AddIdentityCore<ApplicationUser>()
      .AddEntityFrameworkStores<UsersDbContext>()
      .AddDefaultTokenProviders();
    services.AddAuthentication();
    
    // Add User Services
    services.AddScoped<IApplicationUserRepository, EfApplicationUserRepository>();
    
    services.Configure<IdentityOptions>(options =>
    {
      options.Password.RequireDigit = true;
      options.Password.RequireLowercase = true;
      options.Password.RequireUppercase = true;
      options.Password.RequireNonAlphanumeric = true;
      options.Password.RequiredLength = 16;
      options.Password.RequiredUniqueChars = 4;
      
      // Lockout settings
      options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
      options.Lockout.MaxFailedAccessAttempts = 5;
      options.Lockout.AllowedForNewUsers = true;
      
      // User settings
      options.User.RequireUniqueEmail = true;
    });

    services.ConfigureApplicationCookie(options =>
    {
      // Cookie settings
      options.Cookie.HttpOnly = true;
      options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
      options.LoginPath = "/Identity/Account/Login";
      options.AccessDeniedPath = "/Identity/Account/AccessDenied";
      options.SlidingExpiration = true;
    });
    
    mediatRAssemblies.Add(typeof(UserModuleExtensions).Assembly);
    logger.Information("{Module} module services registered", "Users");

    return services;
  }
}
