using ErrorOr;
using MediatR;
using StudentsDashboard.Application.WorkTasks.Queries.DTOs;


namespace StudentsDashboard.Application.WorkTasks.Queries.GetAllWorkTask
{
    public record GetAllWorkTaskQuery(
    ) : IRequest<ErrorOr<List<GetWorkTaskDto>>>;

}
