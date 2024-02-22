using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Contracts.WorkTaskAnswer;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.WorkTasks.Commands.EditWorkTask;

namespace StudentsDashboard.Application.WorkTasks.Commands.DeleteWorkTask
{
    public class DeleteWorkTaskCommandHandler : IRequestHandler<DeleteWorkTaskCommand, ErrorOr<WorkTaskResponse>>
    {
        private readonly IWorkTaskRepository _workTaskRepository;
        private readonly IUserContextGetIdService _userContextGetId;

        public DeleteWorkTaskCommandHandler(IWorkTaskRepository workTaskRepository,IUserContextGetIdService userContextGetId)
        {
            _workTaskRepository = workTaskRepository;
            _userContextGetId = userContextGetId;
        }


        public async Task<ErrorOr<WorkTaskResponse>> Handle(DeleteWorkTaskCommand request, CancellationToken cancellationToken)
        {
            var userId = 1;//_userContextGetId.GetUserId;

            /*            if (userId is null)
                        {
                            return Errors.WorkTask.UserDoesNotLogged;
                        }*/

            int id = request.Id;

            await _workTaskRepository.DeleteTask(id);

            return new WorkTaskResponse("Task delete");
        }


    }
}
