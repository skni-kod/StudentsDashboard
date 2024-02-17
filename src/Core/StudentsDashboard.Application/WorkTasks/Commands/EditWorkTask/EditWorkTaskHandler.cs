using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Contracts.WorkTaskAnswer;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.WorkTasks.Commands.EditWorkTask
{

    public class EditWorkTaskHandler : IRequestHandler<EditWorkTaskCommand, ErrorOr<WorkTaskResponse>>
    {
        private readonly IWorkTaskRepository _workTaskRepository;
        private readonly IUserContextGetIdService _userContextGetId;

        public EditWorkTaskHandler(IWorkTaskRepository workTaskRepository, IUserContextGetIdService userContextGetId)
        {
            _workTaskRepository = workTaskRepository;
            _userContextGetId = userContextGetId;
        }

        public async Task<ErrorOr<WorkTaskResponse>> Handle(EditWorkTaskCommand request, CancellationToken cancellationToken)
        {
            var userId = _userContextGetId.GetUserId;

            if (userId is null)
            {
                return Errors.WorkTask.UserDoesNotLogged;
            }

            var workTask = new WorkTask
            {
                Name = request.Name,
                Description = request.Desciption,
                Date = request.Date
            };

            await _workTaskRepository.EditTask(request.Id,workTask);

            return new WorkTaskResponse("Task edited");
        }
    }
}
