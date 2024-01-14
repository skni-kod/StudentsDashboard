using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Contracts.WorkEventAnswer;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.WorkEvents.Commands.EditWorkEvent;

public class EditWorkEventHandler : IRequestHandler<EditWorkEventCommand, ErrorOr<WorkEventResponse>>
{
    private readonly IWorkEventRepository _workEventRepository;
    private readonly IUserContextGetIdService _userContextGetId;

    public EditWorkEventHandler(IWorkEventRepository workEventRepository, IUserContextGetIdService userContextGetId)
    {
        _workEventRepository = workEventRepository;
        _userContextGetId = userContextGetId;
    }

    public async Task<ErrorOr<WorkEventResponse>> Handle(EditWorkEventCommand request, CancellationToken cancellationToken)
    {
        var UserId = _userContextGetId.GetUserId;

        if (UserId is null)
        {
            return Errors.UserDoesNotLogged.userDoesNotLogged;
        }

        var hasAccess = _workEventRepository.HasPermision((int)UserId, request.Id);

        if (!hasAccess)
        {
            return Errors.OwnerError.ownerError;
        }
        
        var workEvent = new WorkEvent
        {
            Title = request.Title,
            From_Date = request.FromData,
            From_Time = request.FromTime,
            To_Date = request.ToData,
            To_Time = request.ToTime,
            Location = request.Location
        };

        _workEventRepository.editEvent(request.Id, workEvent);

        return new WorkEventResponse("Event edited");
    }
}