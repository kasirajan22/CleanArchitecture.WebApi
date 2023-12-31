namespace WebAPI;
using InfrastructureLayer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

public static class ServiceExtentions
{
public static void ConfigureMSSqlContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetValue("ConStr","");
        services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("InfrastructureLayer"))); //, x => x.MigrationsAssembly("../DomainLayer/DomainLayer")
    }

     public static void ConfigureSingletonServices(this IServiceCollection services)
    {
        // services.AddSingleton<IFileService, FileService>();
    }
}
