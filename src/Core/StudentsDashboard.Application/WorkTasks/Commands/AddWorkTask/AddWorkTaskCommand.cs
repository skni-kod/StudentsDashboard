using MediatR;
using ErrorOr;
using StudentsDashboard.Application.Contracts.WorkTaskAnswer;

namespace StudentsDashboard.Application.WorkTasks.Commands.AddWorkTask
{
    public record AddWorkTaskCommand
    (
        string Name ,
        string Description,
        DateTime Date): IRequest<ErrorOr<WorkTaskResponse>>;
}
