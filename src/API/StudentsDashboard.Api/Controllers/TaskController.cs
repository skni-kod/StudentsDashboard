using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentsDashboard.Application.Contracts.WorkTaskAnswer;
using StudentsDashboard.Application.WorkTasks.Commands.AddWorkTask;
using StudentsDashboard.Application.WorkTasks.Commands.EditWorkTask;



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


        [HttpPost("EditWorkTask")]
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

        /*[HttpPost("GetWorkTask")]
        public async Task<IActionResult> GetWorkTask([FromBody] int id)
        {

            var response = await _mediator.Send(id);

            return response.Match(
                    WorkTaskResponse => Ok(WorkTaskResponse),
                    errors => Problem(errors));
        }

        [HttpPost("DeleteWorkTask")]
        public async Task<IActionResult> DeleteWorkTask([FromBody] int id)
        {
            var response = await _mediator.Send(id);

            return response.Match(
                    WorkTaskResponse => Ok(WorkTaskResponse),
                    errors => Problem(errors));
        }


        [HttpPost("GetAllWorkTask")]
        public async Task<IActionResult> GetAllTask([FromBody] int id)
        {
            var response = await _mediator.Send(id);

            return response.Match(
                    WorkTaskResponse => Ok(WorkTaskResponse),
                    errors => Problem(errors));
        }*/


    }
}
