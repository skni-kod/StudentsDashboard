using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Contracts.WorkTaskAnswer;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Domain.Entities;
using StudentsDashboard.Application.WorkTasks.Queries.DTOs;
using static StudentsDashboard.Application.Common.Errors.Errors;




namespace StudentsDashboard.Application.WorkTasks.Queries.GetWorkTask
{
    public class GetWorkTaskQueryHandler : IRequestHandler<GetWorkTaskQuery, ErrorOr<GetWorkTaskDto>>
    {
        private readonly IWorkTaskRepository _workTaskRepository;
        private readonly IUserContextGetIdService _userContextGetId;


        public GetWorkTaskQueryHandler(IWorkTaskRepository workTaskRepository, IUserContextGetIdService userContextGetId)
        {
            _workTaskRepository = workTaskRepository;
            _userContextGetId = userContextGetId;
        }

        public async Task<ErrorOr<GetWorkTaskDto>> Handle(GetWorkTaskQuery request, CancellationToken cancellationToken)
        {
            var userId = 1; //_userContextGetId.GetUserId;

/*            if (userId is null)
            {
                return Errors.WorkTask.UserDoesNotLogged;
            }*/



            var workTask = await _workTaskRepository.GetTask((int)userId, request.Id);

            if (workTask is null)
            {
                return Errors.WorkTask.NotDataToDisplay;
            }

            GetWorkTaskDto result = new GetWorkTaskDto
            {
                Id = workTask.IdUser,
                Name = workTask.Name,
                Description = workTask.Description,
                Date = workTask.Date
            };



            return result;
        }


    }
}
