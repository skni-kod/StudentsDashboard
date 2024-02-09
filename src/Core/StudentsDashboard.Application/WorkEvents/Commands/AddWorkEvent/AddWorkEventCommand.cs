using MediatR;
using ErrorOr;
using StudentsDashboard.Application.Contracts.WorkEventAnswer;

namespace StudentsDashboard.Application.WorkEvents.Commands.AddWorkEvent;

public record AddWorkEventCommand( string Title,
    DateOnly FromDate,
    TimeOnly FromTime,
    DateOnly ToDate,
    TimeOnly ToTime,
    double? Location) : IRequest<ErrorOr<WorkEventResponse>>;