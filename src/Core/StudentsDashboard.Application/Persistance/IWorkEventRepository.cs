using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.Persistance;

public interface IWorkEventRepository
{
    void createEvent(WorkEvent newEvent);
    void editEvent(int Id, WorkEvent editEvent);
    bool HasPermision(int userId, int eventId);
    void deleteEvent(int eventID);
}