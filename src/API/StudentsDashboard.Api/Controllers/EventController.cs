using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentsDashboard.Application.Contracts.WorkEventAnswer;
using StudentsDashboard.Application.WorkEvents.Commands.AddWorkEvent;
using StudentsDashboard.Application.WorkEvents.Commands.EditWorkEvent;

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
}