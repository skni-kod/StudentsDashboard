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

        if (userId is null) return Errors.UserDoesNotLogged.userDoesNotLogged;

        DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);

        IEnumerable<WorkEvent> events;
        
        if (request.display == DisplayEventsData.Started)
        {
            events = await _workEventRepository.GetUnstartedEvents(currentDate, currentTime, (int)userId);
        }
        else if(request.display == DisplayEventsData.Unstarted)
        {
            events = await _workEventRepository.GetEndedEvents(currentDate, currentTime, (int)userId);
        }
        else if(request.display == DisplayEventsData.Ongoing)
        {
            events = await _workEventRepository.GetOngoingEvents(currentDate, currentTime, (int)userId);
        }
        else
        {
            events = await _workEventRepository.GetAllEvents((int)userId);
        }

        if (!events.Any()) return Errors.NotDataToDisplay.notDataToDisplay;

        var result = events.Select(e => e.AsDto()).ToList();

        return result;
    }
}