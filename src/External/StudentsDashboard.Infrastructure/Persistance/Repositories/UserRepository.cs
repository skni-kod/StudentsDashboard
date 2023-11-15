using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Domain.Entities;
using BC = BCrypt.Net.BCrypt;

namespace StudentsDashboard.Infrastructure.Persistance.Repositories;

public class UserRepository : IUserRepository
{
    private readonly StudentsDashboardDbContext _dbContext;

    public UserRepository(StudentsDashboardDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public User? GetUserByEmail(string email)
    {
        var user =_dbContext.Users.FirstOrDefault(r => r.Email == email);
        return user;
    }

    public void Add(User user)
    {
        user.Password = BC.HashPassword(user.Password);
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }
}