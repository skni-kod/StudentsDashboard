using StudentsDashboard.Domain.Entities;
using StudentsDashboard.Application.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace StudentsDashboard.Infrastructure.Persistance.Repositories;

public class WorkTaskRepository : IWorkTaskRepository
{
    private readonly StudentsDashboardDbContext _dbContext;

    public WorkTaskRepository(StudentsDashboardDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateTask(WorkTask newTask)
    {
        await _dbContext.WorkTasks.AddAsync(newTask);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteTask(int Id)
    {
        var result = await _dbContext.WorkTasks.FindAsync(Id);


        _dbContext.WorkTasks.Remove(result);
        await _dbContext.SaveChangesAsync();
    }

    public async Task EditTask(int Id, WorkTask editedTask)
    {
        var result = await _dbContext.WorkTasks.FindAsync(Id);

        if (result.Name != editedTask.Name)
        {
            result.Name = editedTask.Name;
        }
        if (result.Date != editedTask.Date)
        {
            result.Date = editedTask.Date;
        }
        if(result.Description != editedTask.Description)
        {
            result.Description = editedTask.Description;
        }

        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<WorkTask>> GetAllTask(int Id_USer)
    {
        var taskList = await _dbContext.WorkTasks.
            Where(l => l.IdUser == Id_USer).ToListAsync();

        return taskList;
    }

    public async Task<WorkTask?> GetTask(int Id_User,int Id_Task)
    {
        var task = await _dbContext.WorkTasks.FirstOrDefaultAsync(r => r.Id == Id_Task && r.IdUser == Id_User);
        return task;
    }
}
