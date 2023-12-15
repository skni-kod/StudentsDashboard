using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StudentsDashboard.Application.Common.Behaviors;
using System.Reflection;

namespace StudentsDashboard.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration => 
            configuration.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));


        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}