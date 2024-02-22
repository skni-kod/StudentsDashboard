using Microsoft.EntityFrameworkCore;
using StudentsDashboard.Domain.Entities;
using StudentsDashboard.Infrastructure.Persistance.Repositories;

namespace StudentsDashboard.Infrastructure.Persistance;

public class StudentsDashboardDbContext : DbContext
{
    public StudentsDashboardDbContext(DbContextOptions<StudentsDashboardDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    
    public DbSet<WorkTask> WorkTasks { get; set; }
    
    public DbSet<WorkEvent> WorkEvents { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User
        modelBuilder.Entity<User>()
            .HasIndex(r => r.Email)
            .IsUnique();
    }
}