using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Domain.Entities;
using StudentsDashboard.Application.WorkTasks.Queries.DTOs;


namespace StudentsDashboard.Application.WorkTasks.Queries.GetAllWorkTask
{
    public class GetAllWorkTaskHandler : IRequestHandler<GetAllWorkTaskQuery, ErrorOr<List<GetWorkTaskDto>>>
    {
        private readonly IWorkTaskRepository _workTaskRepository;
        private readonly IUserContextGetIdService _userContextGetId;


        public GetAllWorkTaskHandler(IWorkTaskRepository workTaskRepository, IUserContextGetIdService userContextGetId)
        {
            _workTaskRepository = workTaskRepository;
            _userContextGetId = userContextGetId;
        }

        public async Task<ErrorOr<List<GetWorkTaskDto>>>  Handle(GetAllWorkTaskQuery request,CancellationToken cancellationToken)
        {
            var userId = _userContextGetId.GetUserId;

            if (userId is null)
            {
                return Errors.WorkTask.UserDoesNotLogged;
            }

            IEnumerable<WorkTask> workTasks;

            workTasks = await _workTaskRepository.GetAllTask((int)userId);


            if (!workTasks.Any()) return Errors.WorkTask.NotDataToDisplay;

            List<GetWorkTaskDto> workTaskList = workTasks.Select(x => new GetWorkTaskDto
            {
                Id=x.Id,
                Name=x.Name,
                Description=x.Description,
                Date=x.Date,
            }).ToList();

            return workTaskList;
        }


    }
}
