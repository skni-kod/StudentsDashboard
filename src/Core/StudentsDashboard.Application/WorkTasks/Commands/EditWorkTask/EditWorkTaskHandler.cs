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

        public EditWorkTaskHandler(IWorkTaskRepository workTaskRepository)
        {
            _workTaskRepository = workTaskRepository;
        }

        public async Task<ErrorOr<WorkTaskResponse>> Handle(EditWorkTaskCommand request, CancellationToken cancellationToken)
        {

            var workTask = new WorkTask
            {
                Name = request.Name,
                Desciption = request.Desciption,
                Date = request.Date
            };

            _workTaskRepository.editTask(request.Id,workTask);

            return new WorkTaskResponse("Task added");
        }
    }
}
