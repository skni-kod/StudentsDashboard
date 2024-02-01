using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentsDashboard.Infrastructure.Persistance;

namespace StudentsDashboard.IntegrationTests;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
{
    private readonly IServiceScope _scope;
    protected readonly ISender Sender;
    protected readonly StudentsDashboardDbContext DbContext;
    
    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();

        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = _scope.ServiceProvider.GetRequiredService<StudentsDashboardDbContext>();
        DbContext.Database.Migrate();
    }
}