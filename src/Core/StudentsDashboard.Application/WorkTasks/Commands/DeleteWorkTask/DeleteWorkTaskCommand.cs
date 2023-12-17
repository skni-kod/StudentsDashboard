using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Contracts.WorkTaskAnswer;


namespace StudentsDashboard.Application.WorkTasks.Commands.DeleteWorkTask
{
    public record DeleteWorkTaskCommand
    (
        int Id,
        int IdUser) : IRequest<ErrorOr<WorkTaskResponse>>;

}
