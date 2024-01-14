using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Contracts.WorkEventAnswer;
using StudentsDashboard.Application.Persistance;

namespace StudentsDashboard.Application.WorkEvents.Commands.DeleteWorkEvent;

public class DeleteWorkEventHandler : IRequestHandler<DeleteWorkEventCommand, ErrorOr<WorkEventResponse>>
{
    private readonly IUserContextGetIdService _userContextGetId;
    private readonly IWorkEventRepository _workEventRepository;
    
    public async Task<ErrorOr<WorkEventResponse>> Handle(DeleteWorkEventCommand request, CancellationToken cancellationToken)
    {
        var userId = _userContextGetId.GetUserId;

        if (userId is null) return Errors.UserDoesNotLogged.userDoesNotLogged;

        var hasAcces = _workEventRepository.HasPermision((int)userId, request.id);

        if (!hasAcces) return Errors.OwnerError.ownerError;
        
        _workEventRepository.deleteEvent(request.id);

        return new WorkEventResponse("Success!");
    }
}