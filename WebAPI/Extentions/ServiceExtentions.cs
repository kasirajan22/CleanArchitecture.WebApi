namespace WebAPI;
using InfrastructureLayer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ApplicationLayer;

public static class ServiceExtentions
{
public static void ConfigureMSSqlContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetValue("ConStr","");
        services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("InfrastructureLayer"))); //, x => x.MigrationsAssembly("../DomainLayer/DomainLayer")
    }
    public static void ConfigureWrappers(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        services.AddScoped<IApplicationWrapper, ApplicationWrapper>();
    }
    public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration config)
    {
        var securityKey = config["Authentication:Secret"];
        var issuer = config["Authentication:Issuer"];
        var audience = config["Authentication:Audience"];
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).
        AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)),
                ClockSkew = TimeSpan.Zero
            };
        });
    }
     public static void ConfigureSingletonServices(this IServiceCollection services)
    {
        // services.AddSingleton<IFileService, FileService>();
    }
}
