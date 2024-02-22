using StudentsDashboard.Domain.Entities;
using StudentsDashboard.Application.Persistance;

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
        var result = _dbContext.WorkTasks.SingleOrDefault(c => c.Id == Id);


        _dbContext.WorkTasks.Remove(result);
        _dbContext.SaveChanges();
    }

    public void editTask(int Id, WorkTask editedTask)
    {
        var result = _dbContext.WorkTasks.FirstOrDefault(c => c.Id == Id);

        if (result.Name != editedTask.Name)
        {
            result.Name = editedTask.Name;
        }
        if (result.Date != editedTask.Date)
        {
            result.Date = editedTask.Date;
        }
        if(result.Desciption != editedTask.Desciption)
        {
            result.Desciption = editedTask.Desciption;
        }

        _dbContext.SaveChanges();
    }

    public IEnumerable<WorkTask> getAllTask(int IdUSer)
    {
        var taskList = _dbContext.WorkTasks.ToList().
                        FindAll(l => l.Id_Customer == IdUSer);

        return taskList;
    }

    public WorkTask? getTask(int IdUser,int Id)
    {
        var task= _dbContext.WorkTasks.FirstOrDefault(r => r.Id == Id && r.Id_Customer == IdUser);
        return task;
    }
    
}
