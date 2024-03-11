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

    public DeleteWorkEventHandler(IUserContextGetIdService userContextGetId, IWorkEventRepository workEventRepository)
    {
        _userContextGetId = userContextGetId;
        _workEventRepository = workEventRepository;
    }
    
    public async Task<ErrorOr<WorkEventResponse>> Handle(DeleteWorkEventCommand request, CancellationToken cancellationToken)
    {
        var userId = _userContextGetId.GetUserId;

        if (userId is null) return Errors.WorkEvent.UserDoesNotLogged;

        var hasAcces = await _workEventRepository.HasPermision((int)userId, request.Id);

        if (!hasAcces) return Errors.WorkEvent.OwnerError;
        
        await _workEventRepository.DeleteEvent(request.Id);

        return new WorkEventResponse("Success!");
    }
}