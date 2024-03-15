
using ErrorOr;
using FluentValidation;
using MediatR;
using StudentsDashboard.Application.WorkTasks.Queries.DTOs;


namespace StudentsDashboard.Application.WorkTasks.Queries.GetWorkTask
{

    public record GetWorkTaskQuery(
        int Id
    ) : IRequest<ErrorOr<GetWorkTaskDto>>;

}
