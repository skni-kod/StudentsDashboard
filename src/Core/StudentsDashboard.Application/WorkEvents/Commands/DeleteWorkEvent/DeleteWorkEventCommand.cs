using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Contracts.WorkEventAnswer;

namespace StudentsDashboard.Application.WorkEvents.Commands.DeleteWorkEvent;

public record DeleteWorkEventCommand(
    int id
    ) : IRequest<ErrorOr<WorkEventResponse>>;