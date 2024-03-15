using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StudentsDashboard.Application.Common.Interfaces.Authentication;
using StudentsDashboard.Application.Common.Models;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Infrastructure.Authentication;
using StudentsDashboard.Infrastructure.Persistance;
using StudentsDashboard.Infrastructure.Persistance.Repositories;
using StudentsDashboard.Infrastructure.Persistance.Seeders;
using StudentsDashboard.Infrastructure.Services;

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
        services.AddScoped<Seeder>();

        services.AddScoped<IWorkTaskRepository, WorkTaskRepository>();
        services.AddScoped<IWorkEventRepository, WorkEventRepository>();
        services.AddScoped<IDateService, DateService>();

        services.AddHttpContextAccessor();

        services.AddScoped<IUserContextGetIdService, UserContextGetIdService>();

        services.Configure<EmailSettings>(configuration.GetSection(EmailSettings.SectionName));
        services.AddSingleton<IEmailSender, EmailSender>();
        
        
        return services;
    }

    public static IServiceCollection AddAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        var authenticationSettings = new JwtSettings();
        configuration.GetSection(JwtSettings.SectionName).Bind(authenticationSettings);
        services.AddSingleton(authenticationSettings);

        services.AddAuthentication( opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(cfg =>
        {
            cfg.RequireHttpsMetadata = false;
            cfg.SaveToken = true;
            cfg.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = authenticationSettings.Issuer,
                ValidAudience = authenticationSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.Secret))
            };
        });

        return services;
    }
}