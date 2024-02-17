
using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.Persistance
{
    public interface IWorkTaskRepository
    {

        Task<WorkTask?> GetTask(int Id_User,int Id);

        Task<IEnumerable<WorkTask>> GetAllTask(int Id_User);
        Task CreateTask(WorkTask New_Task);
        Task DeleteTask(int Id);
        Task EditTask(int Id, WorkTask Edited_Task);
    }
}



