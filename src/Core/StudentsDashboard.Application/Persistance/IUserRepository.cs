using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.Persistance;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    bool Any(string email);
    int Add(User user);
    Task<User?> GetUser(string email, string password);
    void VerifyEmail(User user);
}