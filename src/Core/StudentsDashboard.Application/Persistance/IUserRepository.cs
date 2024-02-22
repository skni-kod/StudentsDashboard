using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.Persistance;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    bool Any(string email);
    int Add(User user);
}