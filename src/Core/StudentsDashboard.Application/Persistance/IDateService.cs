namespace StudentsDashboard.Application.Persistance;

public interface IDateService
{
    DateTime CurrentDateTime();
    DateOnly CurrentDateOnly();
    TimeOnly CurrentTimeOnly();
}