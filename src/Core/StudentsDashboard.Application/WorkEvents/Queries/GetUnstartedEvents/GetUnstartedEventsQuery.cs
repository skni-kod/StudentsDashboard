using MediatR;
using ErrorOr;
using StudentsDashboard.Application.WorkEvents.Queries.DTOs;

namespace StudentsDashboard.Application.WorkEvents.Queries.GetUnstartedEvents;

public record GetUnstartedEventsQuery(
    DateOnly CurrentDate,
    TimeOnly CurrentTime
    ) : IRequest<ErrorOr<List<GetEventsDto>>>;