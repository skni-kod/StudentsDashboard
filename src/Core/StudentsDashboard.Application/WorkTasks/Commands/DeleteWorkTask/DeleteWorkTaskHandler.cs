using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Contracts.WorkTaskAnswer;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Domain.Entities;
using StudentsDashboard.Application.WorkTasks.Commands.EditWorkTask;

namespace StudentsDashboard.Application.WorkTasks.Commands.DeleteWorkTask
{
    public class DeleteWorkTaskHandler
    {
        private readonly IWorkTaskRepository _workTaskRepository;
        private readonly IUserContextGetIdService _userContextGetId;

        public DeleteWorkTaskHandler(IWorkTaskRepository workTaskRepository,IUserContextGetIdService userContextGetId)
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

            int Id = request.Id;

            await _workTaskRepository.DeleteTask(Id);

            return new WorkTaskResponse("Task delete");
        }


    }
}
