using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Contracts.WorkTaskAnswer;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Domain.Entities;


namespace StudentsDashboard.Application.WorkTasks.Commands.AddWorkTask
{
    public class AddWorkTaskHandler : IRequestHandler<AddWorkTaskCommand, ErrorOr<WorkTaskResponse>>
    {
        private readonly IWorkTaskRepository _workTaskRepository;

        public AddWorkTaskHandler(IWorkTaskRepository workTaskRepository)
        {
            _workTaskRepository = workTaskRepository;
        }

        public async Task<ErrorOr<WorkTaskResponse>> Handle(AddWorkTaskCommand request, CancellationToken cancellationToken)
        {

            var workTask = new WorkTask
            {
                Name = request.Name,
                Desciption = request.Desciption,
                Date = request.Date
            };

            _workTaskRepository.createTask(workTask);

            return new WorkTaskResponse("Task added");
        }
    }
}

    


