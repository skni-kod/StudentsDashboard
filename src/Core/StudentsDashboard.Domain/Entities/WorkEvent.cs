namespace StudentsDashboard.Domain.Entities;

public class WorkEvent
{
    public int Id_Event { get; set; }
    public int Id_Customer { get; set; }
    public double? Location { get; set; }
    public string Title { get; set; }
    public DateOnly From_Date { get; set; }
    public TimeOnly From_Time { get; set; }
    public DateOnly To_Date { get; set; }
    public TimeOnly To_Time { get; set; }
    
}