namespace StudentsDashboard.Application.Contracts.WorkTaskAnswer
{
    public record WorkTaskRequest(
        int Id,
        string Name,
        string Desciption,
        DateTime Date);
}
