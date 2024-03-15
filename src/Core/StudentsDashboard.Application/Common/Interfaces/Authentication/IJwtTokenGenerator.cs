namespace StudentsDashboard.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    void GenerateToken(int userId, string firstName, string lastName);
}