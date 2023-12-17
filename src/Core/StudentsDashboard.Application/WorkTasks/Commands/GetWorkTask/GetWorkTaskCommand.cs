using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Contracts.WorkTaskAnswer;


namespace StudentsDashboard.Application.WorkTasks.Commands.GetWorkTask
{
    public record GetWorkTaskCommand
    (
        int Id,
        int IdUser) : IRequest<ErrorOr<WorkTaskResponse>>;
    
}



