using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Contracts.WorkEventAnswer;
using StudentsDashboard.Application.WorkEvents.Queries.DTOs;

namespace StudentsDashboard.Application.WorkEvents.Queries.GetSpecificEvent;

public record GetEventQuery(
    int id
    ) : IRequest<ErrorOr<List<GetEventsDto>>>;