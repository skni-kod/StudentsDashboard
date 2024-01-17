using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentsDashboard.Application.Contracts.WorkEventAnswer;
using StudentsDashboard.Application.WorkEvents.Commands.AddWorkEvent;
using StudentsDashboard.Application.WorkEvents.Commands.DeleteWorkEvent;
using StudentsDashboard.Application.WorkEvents.Commands.EditWorkEvent;
using StudentsDashboard.Application.WorkEvents.Queries.GetManyEvents;
using StudentsDashboard.Application.WorkEvents.Queries.GetSpecificEvent;

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

    [HttpGet("GetEvents")]
    public async Task<IActionResult> GetEvents([FromQuery]GetEventsQuery query)
    {
        var respone = await _mediator.Send(query);

        return respone.Match(
            respones => Ok(respones),
            errors => Problem(errors));
    }

    [HttpGet("GetEvent/{id}")]
    public async Task<IActionResult> GetEvent([FromRoute]GetEventQuery query)
    {
        var response = await _mediator.Send(query);

        return response.Match(
            responses => Ok(responses),
            errors => Problem(errors));
    }
    
}