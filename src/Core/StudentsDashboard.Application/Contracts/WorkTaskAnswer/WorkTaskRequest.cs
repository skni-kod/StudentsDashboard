namespace StudentsDashboard.Application.Contracts.WorkTaskAnswer
{
    public record WorkTaskRequest(
        int IdUser,
        int Id,
        string Name,
        string Desciption,
        DateTime Date);
}
