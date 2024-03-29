﻿using Application.Commons.Jwt.Models;
using Application.Commons.Models;
using Application.UseCases.Users.Commands.CreateUser;
using Application.UseCases.Users.Commands.LoginUser;
using Application.UseCases.Users.Commands.RegisterUser;
using Application.UseCases.Users.Queries.GetAll;
using Application.UseCases.Users.Response;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseApiController
{
    [HttpGet("[action]")]
    public async ValueTask<PaginatedList<UserResponse>> GetAllUser([FromQuery] GetAllUserQuery query)
     => await Mediator.Send(query);
    [HttpPost("[action]")]
    public async ValueTask<Guid> CreateUser([FromForm] CreateUserCommand command)
    => await Mediator.Send(command);

    [HttpPost("[action]")]
    public async ValueTask<TokenResponse> RegisterUser([FromForm] RegisterUserCommand command)
  => await Mediator.Send(command);


    [HttpPost("[action]")]
    public async ValueTask<TokenResponse> LoginUser([FromForm] LoginUserCommand command)
        => await Mediator.Send(command);
}
