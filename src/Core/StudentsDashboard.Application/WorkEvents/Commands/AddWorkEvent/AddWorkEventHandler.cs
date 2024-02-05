using MediatR;
using ErrorOr;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Contracts.WorkEventAnswer;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Domain.Entities;


namespace StudentsDashboard.Application.WorkEvents.Commands.AddWorkEvent;

public class AddWorkEventHandler : IRequestHandler<AddWorkEventCommand, ErrorOr<WorkEventResponse>>
{
    private readonly IWorkEventRepository _workEventRepository;
    private readonly IUserContextGetIdService _userContextGetId;

    public AddWorkEventHandler(IWorkEventRepository workEventRepository, IUserContextGetIdService userContextGetId)
    {
        _workEventRepository = workEventRepository;
        _userContextGetId = userContextGetId;
    }

    public async Task<ErrorOr<WorkEventResponse>> Handle(AddWorkEventCommand request, CancellationToken cancellationToken)
    {
        var userId = _userContextGetId.GetUserId;

        if (userId is null)
        {
            return Errors.WorkEvent.userDoesNotLogged;
        }
        
        var workEvent = new WorkEvent
        {
            Id_Customer = (int)userId,
            Title = request.Title,
            From_Date = request.FromDate,
            From_Time = request.FromTime,
            To_Date = request.ToDate,
            To_Time = request.ToTime,
            Location = request.Location
        };

        await _workEventRepository.createEvent(workEvent);

        return new WorkEventResponse("Event added");

    }
}