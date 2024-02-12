namespace StudentsDashboard.Application.Contracts.WorkEventAnswer;

public record WorkEventRequest(
    string Title,
    DateOnly FromDate,
    TimeOnly FromTime,
    DateOnly ToDate,
    TimeOnly ToTime,
    double? Location);