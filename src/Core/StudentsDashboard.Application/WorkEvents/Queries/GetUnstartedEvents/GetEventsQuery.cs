using MediatR;
using ErrorOr;
using StudentsDashboard.Application.WorkEvents.Queries.DTOs;
using StudentsDashboard.Domain.WorkEvents.Enums;

namespace StudentsDashboard.Application.WorkEvents.Queries.GetUnstartedEvents;

public record GetEventsQuery(
    DisplayData? display
    ) : IRequest<ErrorOr<List<GetEventsDto>>>;