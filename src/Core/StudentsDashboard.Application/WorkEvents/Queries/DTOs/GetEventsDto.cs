namespace StudentsDashboard.Application.WorkEvents.Queries.DTOs;

public class GetEventsDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateOnly FromDate { get; set; }
    public TimeOnly FromTime { get; set; }
    public DateOnly ToDate { get; set; }
    public TimeOnly ToTime { get; set; }
    public double? Location { get; set; }
}