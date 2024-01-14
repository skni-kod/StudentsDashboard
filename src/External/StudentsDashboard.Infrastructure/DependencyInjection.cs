using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentsDashboard.Infrastructure.Persistance;
using StudentsDashboard.Infrastructure.Persistance.Repositories;
using StudentsDashboard.Application.Persistance;
using Microsoft.Extensions.Configuration;


namespace StudentsDashboard.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<StudentsDashboardDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Default"),
                r =>
                    r.MigrationsAssembly(typeof(AssemblyReference).Assembly.ToString())));

        services.AddScoped<IWorkTaskRepository, WorkTaskRepository>();
        
        services.AddScoped<IWorkEventRepository, WorkEventRepository>();

        services.AddHttpContextAccessor();

        services.AddScoped<IUserContextGetIdService, UserContextGetIdService>();
        
        return services;
    }
}