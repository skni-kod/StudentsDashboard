namespace StudentsDashboard.Application.Contracts.WorkEventAnswer;

public record WorkEventEditRequest(
    string Title,
    DateOnly FromDate,
    TimeOnly FromTime,
    DateOnly ToDate,
    TimeOnly ToTime,
    double Location
);