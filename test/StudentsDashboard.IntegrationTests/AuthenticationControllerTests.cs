using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using StudentsDashboard.Application.Contracts.Authentication;
using StudentsDashboard.Infrastructure.Persistance;
using StudentsDashboard.IntegrationTests.Helpers;

namespace StudentsDashboard.IntegrationTests;

public class AuthenticationControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public AuthenticationControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var dbContextOptions = services
                        .SingleOrDefault(service =>
                            service.ServiceType == typeof(DbContextOptions<StudentsDashboardDbContext>));

                    services.Remove(dbContextOptions);

                    services.AddDbContext<StudentsDashboardDbContext>(options =>
                        options.UseInMemoryDatabase("StudentsDashboardDb"));
                });
            })
            .CreateClient();
    }

    [Fact]
    public async Task RegisterUser_ForValidModel_ReturnsOk()
    {
        // arrange

        var registerUser = new RegisterRequest(
            FirstName: "Jan",
            LastName: "Nowak",
            Email: "test@test.com",
            Password: "qwerty123",
            ConfirmPassword: "qwerty123"
        );

        var httpContent = registerUser.ToJsonHttpContent();
        
        // act

        var response = await _client.PostAsync("/api/auth/register", httpContent);
        
        // assert 

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Fact]
    public async Task RegisterUser_ForInvalidModel_ReturnsBadRequest()
    {
        // arrange

        var registerUser = new RegisterRequest(
            FirstName: "Jan",
            LastName: "Nowak",
            Email: "test.com",
            Password: "qwerty",
            ConfirmPassword: ""
        );

        var httpContent = registerUser.ToJsonHttpContent();
        
        // act

        var response = await _client.PostAsync("/api/auth/register", httpContent);
        
        // assert 

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}