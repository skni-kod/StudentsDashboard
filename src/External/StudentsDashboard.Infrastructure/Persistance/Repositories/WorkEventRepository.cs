using Microsoft.EntityFrameworkCore;
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

    public async Task createEvent(WorkEvent newEvent)
    {
        await _context.WorkEvents.AddAsync(newEvent);
        await _context.SaveChangesAsync();
    }
    
    public async Task editEvent(int id, WorkEvent editEvent)
    {
        var result = await _context.WorkEvents.FindAsync(id);

        if (result.Title != editEvent.Title) result.Title = editEvent.Title;
        if (result.From_Date != editEvent.From_Date) result.From_Date = editEvent.From_Date;
        if (result.From_Time != editEvent.From_Time) result.From_Time = editEvent.From_Time;
        if (result.To_Date != editEvent.To_Date) result.To_Date = editEvent.To_Date;
        if (result.To_Time != editEvent.To_Time) result.To_Time = editEvent.To_Time;
        if (result.Location != editEvent.Location) result.Location = editEvent.Location;

        await _context.SaveChangesAsync();

    }
    
    public async Task<bool> HasPermision(int userId, int eventId)
    {
        var result = await _context.WorkEvents.FindAsync(eventId);

        return result != null && result.Id_Customer == userId;
    }

    public async Task deleteEvent(int eventId)
    {
        var result = await _context.WorkEvents.FindAsync(eventId);

        _context.WorkEvents.Remove(result);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<WorkEvent>> GetUnstartedEvents(DateOnly currentDate, TimeOnly currentTime, int userId)
    {
        var result = await _context.WorkEvents
            .Where(e => (e.Id_Customer == userId) && 
                         (e.From_Date > currentDate || 
                         (e.From_Date == currentDate && 
                          e.From_Time > currentTime))).ToListAsync();

        if (!result.Any()) result = null;

        return result;
    }

    public async Task<IEnumerable<WorkEvent>> GetEndedEvents(DateOnly currentDate, TimeOnly currentTime, int userId)
    {
        var result = await _context.WorkEvents
            .Where(e =>
                         e.Id_Customer == userId && 
                        (e.To_Date < currentDate ||
                        (e.To_Date == currentDate && 
                         e.To_Time < currentTime))).ToListAsync();
        
        if (!result.Any()) result = null;
        
        return result;
    }

    public async Task<IEnumerable<WorkEvent>> GetOngoingEvents(DateOnly currentDate, TimeOnly currentTime, int userId)
    {
        var result = await _context.WorkEvents
            .Where(e => 
                         e.Id_Customer == userId &&
                        ((e.From_Date < currentDate && e.To_Date > currentDate) || 
                        (e.From_Date == currentDate && e.To_Date == currentDate && e.From_Time <= currentTime && e.To_Time >= currentTime) ||
                        (e.From_Date == currentDate && e.To_Date > currentDate && e.From_Time <= currentTime) || 
                        (e.From_Date < currentDate && e.To_Date == currentDate && e.To_Time >= currentTime))
                        ).ToListAsync();

        if (!result.Any()) result = null;

        return result;
    }

    public async Task<IEnumerable<WorkEvent>> GetAllEvents(int userId)
    {
        var result = await _context.WorkEvents.Where(e => e.Id_Customer == userId).ToListAsync();

        if (!result.Any()) result = null;
        
        return result;
    }
}