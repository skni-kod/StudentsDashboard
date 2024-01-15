using MediatR;
using ErrorOr;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.WorkEvents.Queries.DTOs;

namespace StudentsDashboard.Application.WorkEvents.Queries.GetUnstartedEvents;

public class GetUnstartedEventsHandler : IRequestHandler<GetUnstartedEventsQuery, ErrorOr<List<GetEventsDto>>>
{
    private readonly IUserContextGetIdService _userContextGetId;
    private readonly IWorkEventRepository _workEventRepository;

    public GetUnstartedEventsHandler(IUserContextGetIdService userContextGetId, IWorkEventRepository workEventRepository)
    {
        _userContextGetId = userContextGetId;
        _workEventRepository = workEventRepository;
    }

    public async Task<ErrorOr<List<GetEventsDto>>> Handle(GetUnstartedEventsQuery request, CancellationToken cancellationToken)
    {
        var userId = _userContextGetId.GetUserId;

        if (userId is null) return Errors.UserDoesNotLogged.userDoesNotLogged;

        var events = _workEventRepository.GetUnstartedEvents(request.CurrentDate, request.CurrentTime, (int)userId);

        if (events is null) return Errors.NotDataToDisplay.notDataToDisplay;

        var result = events.Select(e => e.AsDto()).ToList();

        return result;
    }
}