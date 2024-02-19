using Microsoft.EntityFrameworkCore;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Infrastructure.Persistance.Repositories;

public class WorkEventRepository : IWorkEventRepository
{
    private readonly StudentsDashboardDbContext _context;
    private readonly IDateService _dateService;

    public WorkEventRepository(StudentsDashboardDbContext context, IDateService dateService)
    {
        _context = context;
        _dateService = dateService;
    }

    public async Task CreateEvent(WorkEvent newEvent)
    {
        await _context.WorkEvents.AddAsync(newEvent);
        await _context.SaveChangesAsync();
    }
    
    public async Task EditEvent(int id, WorkEvent editEvent)
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

    public async Task DeleteEvent(int eventId)
    {
        var result = await _context.WorkEvents.FindAsync(eventId);

        _context.WorkEvents.Remove(result);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<WorkEvent>> GetUnstartedEvents(int userId)
    {
        var result = await _context.WorkEvents
            .Where(e => (e.Id_Customer == userId) && 
                         (e.From_Date > _dateService.CurrentDateOnly() || 
                         (e.From_Date == _dateService.CurrentDateOnly() && 
                          e.From_Time > _dateService.CurrentTimeOnly()))).ToListAsync();

        return result;
    }

    public async Task<IEnumerable<WorkEvent>> GetEndedEvents(int userId)
    {
        var result = await _context.WorkEvents
            .Where(e =>
                         e.Id_Customer == userId && 
                        (e.To_Date < _dateService.CurrentDateOnly() ||
                        (e.To_Date == _dateService.CurrentDateOnly() && 
                         e.To_Time < _dateService.CurrentTimeOnly()))).ToListAsync();
        
        return result;
    }

    public async Task<IEnumerable<WorkEvent>> GetOngoingEvents(int userId)
    {
        var result = await _context.WorkEvents
            .Where(e => 
                         e.Id_Customer == userId &&
                        ((e.From_Date < _dateService.CurrentDateOnly() && e.To_Date > _dateService.CurrentDateOnly()) || 
                        (e.From_Date == _dateService.CurrentDateOnly() && e.To_Date == _dateService.CurrentDateOnly() && e.From_Time <= _dateService.CurrentTimeOnly() && e.To_Time >= _dateService.CurrentTimeOnly()) ||
                        (e.From_Date == _dateService.CurrentDateOnly() && e.To_Date > _dateService.CurrentDateOnly() && e.From_Time <= _dateService.CurrentTimeOnly()) || 
                        (e.From_Date < _dateService.CurrentDateOnly() && e.To_Date == _dateService.CurrentDateOnly() && e.To_Time >= _dateService.CurrentTimeOnly()))
                        ).ToListAsync();

        return result;
    }

    public async Task<IEnumerable<WorkEvent>> GetAllEvents(int userId)
    {
        var result = await _context.WorkEvents.Where(e => e.Id_Customer == userId).ToListAsync();
        
        return result;
    }

    public async Task<IEnumerable<WorkEvent>> GetEvent(int eventId)
    {
        var result = await _context.WorkEvents.FindAsync(eventId);
        
        return new List<WorkEvent>() { result };
    }

}