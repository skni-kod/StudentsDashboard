using MediatR;
using ErrorOr;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.WorkEvents.Queries.DTOs;
using StudentsDashboard.Domain.Entities;
using StudentsDashboard.Domain.WorkEvents.Enums;

namespace StudentsDashboard.Application.WorkEvents.Queries.GetManyEvents;

public class GetEventsHandler : IRequestHandler<GetEventsQuery, ErrorOr<List<GetEventsDto>>>
{
    private readonly IUserContextGetIdService _userContextGetId;
    private readonly IWorkEventRepository _workEventRepository;

    public GetEventsHandler(IUserContextGetIdService userContextGetId, IWorkEventRepository workEventRepository)
    {
        _userContextGetId = userContextGetId;
        _workEventRepository = workEventRepository;
    }

    public async Task<ErrorOr<List<GetEventsDto>>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
    {
        var userId = _userContextGetId.GetUserId;

        if (userId is null) return Errors.WorkEvent.UserDoesNotLogged;

        IEnumerable<WorkEvent> events;
        
        if (request.Display == DisplayEventsData.Started)
        {
            events = await _workEventRepository.GetUnstartedEvents((int)userId);
        }
        else if(request.Display == DisplayEventsData.Unstarted)
        {
            events = await _workEventRepository.GetEndedEvents((int)userId);
        }
        else if(request.Display == DisplayEventsData.Ongoing)
        {
            events = await _workEventRepository.GetOngoingEvents((int)userId);
        }
        else
        {
            events = await _workEventRepository.GetAllEvents((int)userId);
        }

        if (!events.Any()) return Errors.WorkEvent.NotDataToDisplay;

        var result = events.Select(e => e.AsDto()).ToList();

        return result;
    }
}