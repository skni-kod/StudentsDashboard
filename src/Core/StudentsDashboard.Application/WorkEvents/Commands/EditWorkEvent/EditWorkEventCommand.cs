using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Contracts.WorkEventAnswer;

namespace StudentsDashboard.Application.WorkEvents.Commands.EditWorkEvent;

public record EditWorkEventCommand(
    int Id,
    string Title,
    DateOnly FromData,
    TimeOnly FromTime,
    DateOnly ToData,
    TimeOnly ToTime,
    double Location
) : IRequest<ErrorOr<WorkEventResponse>>;