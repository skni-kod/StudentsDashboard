using StudentsDashboard.Domain.Entities;
using StudentsDashboard.Application.Persistance;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;

namespace StudentsDashboard.Infrastructure.Persistance.Repositories;

public class WorkTaskRepository : IWorkTaskRepository
{
    private readonly StudentsDashboardDbContext _dbContext;

    public WorkTaskRepository(StudentsDashboardDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void createTask(WorkTask newTask)
    {
        _dbContext.WorkTasks.Add(newTask);
        _dbContext.SaveChanges();
    }

    public void deleteTask(int Id)
    {
        var result = _dbContext.WorkTasks.SingleOrDefault(c => c.Id_Task == Id);


        _dbContext.WorkTasks.Remove(result);
        _dbContext.SaveChanges();
    }

    public void editTask(int Id, WorkTask editedTask)
    {
        var result = _dbContext.WorkTasks.FirstOrDefault(c => c.Id_Task == Id);

        if (result.name != editedTask.name)
        {
            result.name = editedTask.name;
        }
        if (result.date != editedTask.date)
        {
            result.date = editedTask.date;
        }
        if(result.desciption != editedTask.desciption)
        {
            result.desciption = editedTask.desciption;
        }

        _dbContext.SaveChanges();
    }

    public IEnumerable<WorkTask> getAllTask(int IdUSer)
    {
        var taskList = _dbContext.WorkTasks.ToList().
                        FindAll(l => l.Id_Customer == IdUSer);

        return taskList;
    }

    public WorkTask? getTask(int Id)
    {
        var task= _dbContext.WorkTasks.FirstOrDefault(r => r.Id_Task == Id);
        return task;
    }
}
