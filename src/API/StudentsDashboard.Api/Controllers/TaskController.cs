﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentsDashboard.Application.Contracts.WorkTaskAnswer;
using StudentsDashboard.Application.WorkTasks.Commands.AddWorkTask;
using StudentsDashboard.Application.WorkTasks.Commands.EditWorkTask;
using StudentsDashboard.Application.WorkTasks.Commands.GetWorkTask;
using StudentsDashboard.Application.WorkTasks.Commands.GetAllWorkTask;
using StudentsDashboard.Application.WorkTasks.Commands.DeleteWorkTask;

using static StudentsDashboard.Application.Common.Errors.Errors;



namespace StudentsDashboard.Api.Controllers
{

    [ApiController]
    [Route("api/WorkTask")]
    public class TaskController : ApiController
    {
        private readonly ISender _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddWorkTask")]
        public async Task<IActionResult> AddWorkTask([FromBody] WorkTaskRequest request)
        {
            var command = new AddWorkTaskCommand(
                request.Name,
                request.Desciption,
                request.Date
                    );

            var response  = await _mediator.Send(command);

            return response.Match(
                    WorkTaskResponse => Ok(WorkTaskResponse),
                    errors => Problem(errors));
        }


        [HttpPut("EditWorkTask")]
        public async Task<IActionResult> EditWorkTask([FromBody] WorkTaskRequest request)
        {
            var command = new EditWorkTaskCommand(
                request.Id,
                request.Name,
                request.Desciption,
                request.Date
                    );

            var response = await _mediator.Send(command);

            return response.Match(
                    WorkTaskResponse => Ok(WorkTaskResponse),
                    errors => Problem(errors));
        }

        [HttpDelete("DeleteWorkTask")]
        public async Task<IActionResult> DeleteWorkTask([FromBody] int Id, int IdUser)
        {
            var command = new DeleteWorkTaskCommand(
                Id,
                IdUser
                );

            var response = await _mediator.Send(command);

            return response.Match(
                    WorkTaskResponse => Ok(WorkTaskResponse),
                    errors => Problem(errors));
        }

        [HttpGet("GetWorkTask")]
        public async Task<IActionResult> GetWorkTask([FromBody] int Id, int IdUser)
        {
            var command = new GetWorkTaskCommand(
                Id,
                IdUser
                );

            var response = await _mediator.Send(command);

            return response.Match(
                    WorkTaskResponse => Ok(WorkTaskResponse),
                    errors => Problem(errors));
        }

        [HttpGet("GetAllWorkTask")]
        public async Task<IActionResult> GetAllTask([FromBody] int IdUser)
        {
            var command = new GetAllWorkTaskCommand(
                    IdUser
                    );


            var response = await _mediator.Send(command);

            return response.Match(
                    WorkTaskResponse => Ok(WorkTaskResponse),
                    errors => Problem(errors));
        }


    }
}
