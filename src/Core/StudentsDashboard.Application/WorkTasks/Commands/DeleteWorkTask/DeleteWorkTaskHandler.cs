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

        public DeleteWorkTaskHandler(IWorkTaskRepository workTaskRepository)
        {
            _workTaskRepository = workTaskRepository;
        }


        public async Task<ErrorOr<WorkTaskResponse>> Handle(EditWorkTaskCommand request, CancellationToken cancellationToken)
        {

            int Id = request.Id;

            _workTaskRepository.deleteTask(Id);

            return new WorkTaskResponse("Task delete");
        }


    }
}
