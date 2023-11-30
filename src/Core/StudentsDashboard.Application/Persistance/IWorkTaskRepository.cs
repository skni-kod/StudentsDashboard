using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.Persistance
{
    public interface IWorkTaskRepository
    {
        WorkTask? getTask(int Id);
        IEnumerable<WorkTask> getAllTask(int IdUser);
        void createTask(WorkTask newTask);
        void deleteTask(int Id);
        void editTask(int Id,WorkTask editedTask);

    }
}

