using MediatR;
using ErrorOr;
using StudentsDashboard.Application.WorkEvents.Queries.DTOs;
using StudentsDashboard.Domain.WorkEvents.Enums;

namespace StudentsDashboard.Application.WorkEvents.Queries.GetManyEvents;

public record GetEventsQuery(
    DisplayEventsData? Display
    ) : IRequest<ErrorOr<List<GetEventsDto>>>;