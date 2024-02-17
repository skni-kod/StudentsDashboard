
using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.Persistance
{
    public interface IWorkTaskRepository
    {

        WorkTask? GetTask(int IdUser,int Id);
        IEnumerable<WorkTask> GetAllTask(int IdUser);
        void CreateTask(WorkTask newTask);
        void DeleteTask(int Id);
        void EditTask(int Id, WorkTask editedTask);
    }
}



