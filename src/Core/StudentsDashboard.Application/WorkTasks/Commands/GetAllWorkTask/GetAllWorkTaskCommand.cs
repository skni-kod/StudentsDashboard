using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Contracts.WorkTaskAnswer;


namespace StudentsDashboard.Application.WorkTasks.Commands.GetAllWorkTask
{
    public record GetAllWorkTaskCommand
    (
        int IdUser):IRequest<ErrorOr<WorkTaskResponse>>;
}
