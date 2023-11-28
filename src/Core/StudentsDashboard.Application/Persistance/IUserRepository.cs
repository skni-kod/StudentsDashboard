using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.Persistance;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    bool Any(string email);
    void Add(User user);
}