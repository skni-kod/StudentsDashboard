using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Contracts.WorkTaskAnswer;


namespace StudentsDashboard.Application.WorkTasks.Commands.EditWorkTask
{
    public record EditWorkTaskCommand
    (
        int Id,
        string Name,
        string Desciption,
        DateTime Date) : IRequest<ErrorOr<WorkTaskResponse>>;

}
