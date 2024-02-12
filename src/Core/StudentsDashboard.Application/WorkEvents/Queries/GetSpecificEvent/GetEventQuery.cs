using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Contracts.WorkEventAnswer;
using StudentsDashboard.Application.WorkEvents.Queries.DTOs;

namespace StudentsDashboard.Application.WorkEvents.Queries.GetSpecificEvent;

public record GetEventQuery(
    int Id
    ) : IRequest<ErrorOr<List<GetEventsDto>>>;