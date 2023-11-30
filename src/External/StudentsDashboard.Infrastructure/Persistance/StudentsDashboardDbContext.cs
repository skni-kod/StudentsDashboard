using Microsoft.EntityFrameworkCore;
using StudentsDashboard.Domain.Entities;
using StudentsDashboard.Infrastructure.Persistance.Repositories;

namespace StudentsDashboard.Infrastructure.Persistance;

public class StudentsDashboardDbContext : DbContext
{
    public StudentsDashboardDbContext(DbContextOptions<StudentsDashboardDbContext> options) : base(options)
    {
        
    }

    public DbSet<WorkTask> WorkTasks { get; set; }

    


}