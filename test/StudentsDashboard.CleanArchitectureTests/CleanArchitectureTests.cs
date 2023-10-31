using System.Reflection;
using FluentAssertions;
using NetArchTest.Rules;
using StudentsDashboard.Domain;

namespace StudentsDashboard.CleanArchitectureTests;

public class CleanArchitectureTests
{
    private const string DomainNamespace = "StudentsDashboard.Domain";
    private const string ApplicationNamespace = "StudentsDashboard.Application";
    private const string InfrastructureNamespace = "StudentsDashboard.Infrastructure";
    private const string PresentationNamespace = "StudentsDashboard.Presentation";
    private const string WebApiNamespace = "StudentsDashboard.Api";

    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        
        var assembly = typeof(StudentsDashboard.Domain.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            PresentationNamespace,
            WebApiNamespace
        };
        
        // Act
        
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult()
            .IsSuccessful;
        
        // Assert

        testResult.Should().BeTrue();
    }
    
    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        
        var assembly = typeof(StudentsDashboard.Application.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace,
            PresentationNamespace,
            WebApiNamespace
        };
        
        // Act
        
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult()
            .IsSuccessful;
        
        // Assert

        testResult.Should().BeTrue();
    }
    
    [Fact]
    public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        
        var assembly = typeof(StudentsDashboard.Infrastructure.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            PresentationNamespace,
            WebApiNamespace
        };
        
        // Act
        
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult()
            .IsSuccessful;
        
        // Assert

        testResult.Should().BeTrue();
    }
    
    [Fact]
    public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        
        var assembly = typeof(StudentsDashboard.Presentation.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace,
            WebApiNamespace
        };
        
        // Act
        
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult()
            .IsSuccessful;
        
        // Assert

        testResult.Should().BeTrue();
    }
    
}