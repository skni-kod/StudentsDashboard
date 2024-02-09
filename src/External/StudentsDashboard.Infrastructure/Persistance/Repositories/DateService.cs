using StudentsDashboard.Application.Persistance;

namespace StudentsDashboard.Infrastructure.Persistance.Repositories;

public class DateService : IDateService
{
    public DateTime CurrentDateTime() => DateTime.Now;
    public DateOnly CurrentDateOnly() => DateOnly.FromDateTime(DateTime.Now);
    public TimeOnly CurrentTimeOnly() => TimeOnly.FromDateTime(DateTime.Now);
}