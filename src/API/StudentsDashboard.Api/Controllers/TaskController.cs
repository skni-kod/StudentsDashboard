using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentsDashboard.Application.Contracts.WorkTaskAnswer;
using StudentsDashboard.Application.WorkTasks.Commands.AddWorkTask;
using StudentsDashboard.Application.WorkTasks.Commands.EditWorkTask;
using StudentsDashboard.Application.WorkTasks.Commands.DeleteWorkTask;

using static StudentsDashboard.Application.Common.Errors.Errors;
using StudentsDashboard.Application.WorkTasks.Queries.GetAllWorkTask;
using StudentsDashboard.Application.WorkTasks.Queries.GetWorkTask;



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
        public async Task<IActionResult> DeleteWorkTask([FromBody] int Id)
        {
            var command = new DeleteWorkTaskCommand(
                Id
                );

            var response = await _mediator.Send(command);

            return response.Match(
                    WorkTaskResponse => Ok(WorkTaskResponse),
                    errors => Problem(errors));
        }


        /// <summary>
        /// Display one specific event
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("GetWorkTask")]
        public async Task<IActionResult> GetWorkTask([FromQuery] GetWorkTaskQuery query)
        {
            var response = await _mediator.Send(query);

            return response.Match(
                    WorkTaskResponse => Ok(WorkTaskResponse),
                    errors => Problem(errors));
        }



        /// <summary>
        /// Display one specific event
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("GetAllWorkTask")]
        public async Task<IActionResult> GetAllTask([FromQuery] GetAllWorkTaskQuery query)
        {
            var response = await _mediator.Send(query);

            return response.Match(
                    WorkTaskResponse => Ok(WorkTaskResponse),
                    errors => Problem(errors));
        }


    }
}
