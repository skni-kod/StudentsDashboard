using Microsoft.EntityFrameworkCore;
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

    public async Task<User?> GetUser(string email, string password)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

        if (user is null) return null;
        

        var passwordVerification = BCrypt.Net.BCrypt.Verify(password, user.Password);

        if (!passwordVerification) return null;

        return user;
    }
}