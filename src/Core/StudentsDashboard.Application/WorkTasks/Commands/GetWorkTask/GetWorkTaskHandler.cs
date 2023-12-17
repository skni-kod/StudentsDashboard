using ErrorOr;
using StudentsDashboard.Application.Contracts.WorkTaskAnswer;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.WorkTasks.Commands.GetAllWorkTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDashboard.Application.WorkTasks.Commands.GetWorkTask
{
    public class GetWorkTaskHandler
    {
        private readonly IWorkTaskRepository _workTaskRepository;


        public GetWorkTaskHandler (IWorkTaskRepository workTaskRepository)
        { 
            _workTaskRepository = workTaskRepository; 
        }

        public async Task<ErrorOr<WorkTaskResponse>> Handle(GetWorkTaskCommand request, CancellationToken cancellationToken)
        {

            _workTaskRepository.getTask(request.IdUser,request.Id);

            return new WorkTaskResponse("Task all user");
        }


    }
}
