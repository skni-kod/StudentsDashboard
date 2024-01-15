using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentsDashboard.Application.Contracts.WorkEventAnswer;
using StudentsDashboard.Application.WorkEvents.Commands.AddWorkEvent;
using StudentsDashboard.Application.WorkEvents.Commands.DeleteWorkEvent;
using StudentsDashboard.Application.WorkEvents.Commands.EditWorkEvent;
using StudentsDashboard.Application.WorkEvents.Queries.GetUnstartedEvents;

namespace StudentsDashboard.Api.Controllers;

[ApiController]
[Route("api/Events")]
public class EventController : ApiController
{
    private readonly ISender _mediator;

    public EventController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("AddWorkEvent")]
    public async Task<IActionResult> AddWorkEvent([FromBody] WorkEventRequest request)
    {
        var command = new AddWorkEventCommand(
            request.Title,
            request.FromDate,
            request.FromTime,
            request.ToDate,
            request.ToTime,
            request.Location
        );

        var response = await _mediator.Send(command);

        return response.Match(
            WorkEventResponse => Ok(WorkEventResponse), 
            errors => Problem(errors));
    }
    
    [HttpPut("EditWorkEvent/{id}")]
    public async Task<IActionResult> EditWorkEvent([FromBody] WorkEventRequest request, [FromRoute] int id)
    {
        var command = new EditWorkEventCommand(
            id,
            request.Title,
            request.FromDate,
            request.FromTime,
            request.ToDate,
            request.ToTime,
            request.Location
        );

        var response = await _mediator.Send(command);

        return response.Match(
            WorkEventResponse => Ok(WorkEventResponse),
            errors => Problem(errors));
    }

    [HttpDelete("DeleteWorkEvent/{id}")]
    public async Task<IActionResult> DeleteWorkEvent([FromRoute] int id)
    {
        var command = new DeleteWorkEventCommand(id);

        var response = await _mediator.Send(command);

        return response.Match(
            WorkEventResponse => Ok(WorkEventResponse),
            errors => Problem(errors));
    }

    [HttpGet("GetUnstartedEvents")]
    public async Task<IActionResult> GetUnstartedEvents()
    {
        var query = new GetUnstartedEventsQuery(DateOnly.FromDateTime(DateTime.Now), 
            TimeOnly.FromDateTime(DateTime.Now));

        var respone = await _mediator.Send(query);

        return Ok(respone);
    }
}