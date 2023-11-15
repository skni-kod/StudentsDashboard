using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentsDashboard.Application.Common.Interfaces.Authentication;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Infrastructure.Authentication;
using StudentsDashboard.Infrastructure.Persistance;
using StudentsDashboard.Infrastructure.Persistance.Repositories;

namespace StudentsDashboard.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddDbContext<StudentsDashboardDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Default"),
                r =>
                    r.MigrationsAssembly(typeof(AssemblyReference).Assembly.ToString())));
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}