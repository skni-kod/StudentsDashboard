using System.Security.Cryptography;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentsDashboard.Application.Authentication.Commands.Register;
using StudentsDashboard.Application.Contracts.Authentication;

namespace StudentsDashboard.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : ApiController
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

        var response = await _mediator.Send(command);
        return response.Match(
            registerResponse => Ok(registerResponse),
            errors => Problem(errors));
    }
}