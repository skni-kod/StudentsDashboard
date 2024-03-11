using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.Persistance;

public interface IWorkEventRepository
{
    Task CreateEvent(WorkEvent newEvent);
    Task EditEvent(int id, WorkEvent editEvent);
    Task<bool> HasPermision(int userId, int eventId);
    Task DeleteEvent(int eventId);
    Task<IEnumerable<WorkEvent>> GetUnstartedEvents(int userId);
    Task<IEnumerable<WorkEvent>> GetEndedEvents(int userId);
    Task<IEnumerable<WorkEvent>> GetOngoingEvents(int userId);
    Task<IEnumerable<WorkEvent>> GetAllEvents(int userId);
    Task<IEnumerable<WorkEvent>> GetEvent(int eventId, int userId);
}