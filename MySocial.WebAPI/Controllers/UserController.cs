﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using MySocial.Application.Features.User.Commands.CreateUser;

namespace MySocial.WebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        var user = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreateUser), user);
    }
}
