using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Infrastructure.Persistance.Repositories;

public class WorkEventRepository : IWorkEventRepository
{
    private readonly StudentsDashboardDbContext _context;

    public WorkEventRepository(StudentsDashboardDbContext context)
    {
        _context = context;
    }

    public void createEvent(WorkEvent newEvent)
    {
        _context.WorkEvents.Add(newEvent);
        _context.SaveChanges();
    }
    
    public void editEvent(int Id, WorkEvent editEvent)
    {
        var result = _context.WorkEvents.FirstOrDefault(x => x.Id_Event == Id);

        if (result.Title != editEvent.Title) result.Title = editEvent.Title;
        if (result.From_Date != editEvent.From_Date) result.From_Date = editEvent.From_Date;
        if (result.From_Time != editEvent.From_Time) result.From_Time = editEvent.From_Time;
        if (result.To_Date != editEvent.To_Date) result.To_Date = editEvent.To_Date;
        if (result.To_Time != editEvent.To_Time) result.To_Time = editEvent.To_Time;
        if (result.Location != editEvent.Location) result.Location = editEvent.Location;

        _context.SaveChanges();

    }
    
    public bool HasPermision(int userId, int eventId)
    {
        var result = _context.WorkEvents.FirstOrDefault(x => x.Id_Event == eventId);

        return result != null && result.Id_Customer == userId;
    }
}