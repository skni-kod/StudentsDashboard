using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.WorkEvents.Queries.DTOs;
using StudentsDashboard.Application.WorkEvents.Queries.GetManyEvents;

namespace StudentsDashboard.Application.WorkEvents.Queries.GetSpecificEvent;

public class GetEventHandler : IRequestHandler<GetEventQuery, ErrorOr<List<GetEventsDto>>>
{
    private readonly IUserContextGetIdService _userContextGetId;
    private readonly IWorkEventRepository _workEventRepository;

    public GetEventHandler(IUserContextGetIdService userContextGetId, IWorkEventRepository workEventRepository)
    {
        _userContextGetId = userContextGetId;
        _workEventRepository = workEventRepository;
    }
    
    public async Task<ErrorOr<List<GetEventsDto>>> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        var userId = _userContextGetId.GetUserId;

        if (userId is null) return Errors.WorkEvent.UserDoesNotLogged;

        var events = await _workEventRepository.GetEvent(request.Id);

        if (!events.Any()) return Errors.WorkEvent.NotDataToDisplay;

        var result = events.Select(e => e.AsDto()).ToList();

        return result;
    }
}