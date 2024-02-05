using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Contracts.WorkEventAnswer;
using StudentsDashboard.Application.Persistance;

namespace StudentsDashboard.Application.WorkEvents.Commands.DeleteWorkEvent;

public class DeleteWorkEventHandler : IRequestHandler<DeleteWorkEventCommand, ErrorOr<WorkEventResponse>>
{
    private readonly IUserContextGetIdService _userContextGetId;

    public DeleteWorkEventHandler(IUserContextGetIdService userContextGetId, IWorkEventRepository workEventRepository)
    {
        _userContextGetId = userContextGetId;
        _workEventRepository = workEventRepository;
    }

    private readonly IWorkEventRepository _workEventRepository;
    
    public async Task<ErrorOr<WorkEventResponse>> Handle(DeleteWorkEventCommand request, CancellationToken cancellationToken)
    {
        var userId = _userContextGetId.GetUserId;

        if (userId is null) return Errors.WorkEvent.userDoesNotLogged;

        var hasAcces = await _workEventRepository.HasPermision((int)userId, request.id);

        if (!hasAcces) return Errors.WorkEvent.ownerError;
        
        await _workEventRepository.deleteEvent(request.id);

        return new WorkEventResponse("Success!");
    }
}