﻿using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Contracts.WorkTaskAnswer;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Domain.Entities;


namespace StudentsDashboard.Application.WorkTasks.Commands.AddWorkTask
{
    public class AddWorkTaskCommandHandler : IRequestHandler<AddWorkTaskCommand, ErrorOr<WorkTaskResponse>>
    {
        private readonly IWorkTaskRepository _workTaskRepository;
        private readonly IUserContextGetIdService _userContextGetId;

        public AddWorkTaskCommandHandler(IWorkTaskRepository workTaskRepository, IUserContextGetIdService userContextGetId)
        {
            _workTaskRepository = workTaskRepository;
            _userContextGetId = userContextGetId;
        }

        public async Task<ErrorOr<WorkTaskResponse>> Handle(AddWorkTaskCommand request, CancellationToken cancellationToken)
        {
            var userId = 1;//_userContextGetId.GetUserId;

/*            if (userId is null)
            {
                return Errors.WorkTask.UserDoesNotLogged;
            }*/


            var workTask = new WorkTask
            {
                IdUser = (int)userId,
                Name = request.Name,
                Description = request.Description,
                Date = request.Date
            };

            await _workTaskRepository.CreateTask(workTask);

            return new WorkTaskResponse("Task added");
        }
    }
}

    

