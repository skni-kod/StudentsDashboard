using MediatR;
using Microsoft.AspNetCore.Authorization;
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
[Authorize]
[Route("api/events")]
public class EventController : ApiController
{
    private readonly ISender _mediator;

    public EventController(ISender mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Add new event
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
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
            responses => Ok(responses), 
            errors => Problem(errors));
    }
    
    /// <summary>
    /// Editing an existing event
    /// </summary>
    /// <param name="request"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
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
            responses => Ok(responses),
            errors => Problem(errors));
    }

    /// <summary>
    /// Delete an existing event
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkEvent([FromRoute] int id)
    {
        var command = new DeleteWorkEventCommand(id);

        var response = await _mediator.Send(command);

        return response.Match(
            responses => Ok(responses),
            errors => Problem(errors));
    }

    /// <summary>
    /// Display all events
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetEvents([FromQuery]GetEventsQuery query)
    {
        var respone = await _mediator.Send(query);

        return respone.Match(
            responses => Ok(responses),
            errors => Problem(errors));
    }

    
    /// <summary>
    /// Display one specific event
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEvent([FromRoute]GetEventQuery query)
    {
        var response = await _mediator.Send(query);

        return response.Match(
            responses => Ok(responses),
            errors => Problem(errors));
    }
    
}