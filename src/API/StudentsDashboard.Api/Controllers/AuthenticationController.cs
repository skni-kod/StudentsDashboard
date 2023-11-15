using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentsDashboard.Application.Authentication.Commands.Register;
using StudentsDashboard.Application.Contracts.Authentication;

namespace StudentsDashboard.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly ISender _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password,
            request.ConfirmPassword);

        await _mediator.Send(command);
        return Ok();
    }
}