using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Contracts.WorkTaskAnswer;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Domain.Entities;
using StudentsDashboard.Application.WorkTasks.Commands.EditWorkTask;


namespace StudentsDashboard.Application.WorkTasks.Commands.GetAllWorkTask
{
    public class GetAllWorkTaskHandler
    {
        private readonly IWorkTaskRepository _workTaskRepository;

        public GetAllWorkTaskHandler(IWorkTaskRepository workTaskRepository)
        {
            _workTaskRepository = workTaskRepository;
        }

        public async Task<ErrorOr<WorkTaskResponse>> Handle(GetAllWorkTaskCommand request, CancellationToken cancellationToken)
        {

            _workTaskRepository.GetAllTask(request.IdUser);

            return new WorkTaskResponse("Task all user");
        }

    }
}
