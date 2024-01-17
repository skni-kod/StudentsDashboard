using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.Persistance;

public interface IWorkEventRepository
{
    Task createEvent(WorkEvent newEvent);
    Task editEvent(int Id, WorkEvent editEvent);
    Task<bool> HasPermision(int userId, int eventId);
    Task deleteEvent(int eventID);
    Task<IEnumerable<WorkEvent>> GetUnstartedEvents(DateOnly currentDate, TimeOnly currentTime, int userId);
    Task<IEnumerable<WorkEvent>> GetEndedEvents(DateOnly currentDate, TimeOnly currentTime, int userId);
    Task<IEnumerable<WorkEvent>> GetOngoingEvents(DateOnly currentDate, TimeOnly currentTime, int userId);
    Task<IEnumerable<WorkEvent>> GetAllEvents(int userId);
    Task<IEnumerable<WorkEvent>> GetEvent(int eventId);
}