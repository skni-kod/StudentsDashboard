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
        ConfigurationManager configuration)
    {
        services.AddDbContext<StudentsDashboardDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Default"),
                r =>
                    r.MigrationsAssembly(typeof(AssemblyReference).Assembly.ToString())));

        services.AddScoped<IWorkTaskRepository, WorkTaskRepository>();

        return services;
    }
}