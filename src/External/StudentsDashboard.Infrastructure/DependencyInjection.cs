using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentsDashboard.Application.Common.Interfaces.Authentication;
using StudentsDashboard.Infrastructure.Authentication;

namespace StudentsDashboard.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}