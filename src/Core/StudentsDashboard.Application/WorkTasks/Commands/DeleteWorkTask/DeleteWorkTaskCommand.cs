using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Contracts.WorkTaskAnswer;


namespace StudentsDashboard.Application.WorkTasks.Commands.DeleteWorkTask
{
    public record DeleteWorkTaskCommand
    (
        int Id
        ) : IRequest<ErrorOr<WorkTaskResponse>>;

}
