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

    public bool Any(string email)
    {
        var isExist = _dbContext.Users.Any(r => r.Email == email);
        return isExist;
    }

    public int Add(User user)
    {
        user.Password = BC.HashPassword(user.Password);
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();

        return user.Id;
    }

    public void VerifyEmail(User user)
    {
        user.VerificationToken = null;
        user.VerifiedAt = DateTime.UtcNow;
        _dbContext.SaveChanges();
    }
}