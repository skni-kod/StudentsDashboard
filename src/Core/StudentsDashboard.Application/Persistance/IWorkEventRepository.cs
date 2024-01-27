using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.Persistance;

public interface IWorkEventRepository
{
    Task createEvent(WorkEvent newEvent);
    Task editEvent(int Id, WorkEvent editEvent);
    Task<bool> HasPermision(int userId, int eventId);
    Task deleteEvent(int eventID);
    Task<IEnumerable<WorkEvent>> GetUnstartedEvents(int userId);
    Task<IEnumerable<WorkEvent>> GetEndedEvents(int userId);
    Task<IEnumerable<WorkEvent>> GetOngoingEvents(int userId);
    Task<IEnumerable<WorkEvent>> GetAllEvents(int userId);
    Task<IEnumerable<WorkEvent>> GetEvent(int eventId);
}