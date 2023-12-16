using Application.Features.AppUsers.Commands.Create;
using Application.Features.AppUsers.Commands.Delete;
using Application.Features.AppUsers.Commands.Update;
using Application.Features.AppUsers.Queries.GetById;
using Application.Features.AppUsers.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppUsersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAppUserCommand createAppUserCommand)
    {
        CreatedAppUserResponse response = await Mediator.Send(createAppUserCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAppUserCommand updateAppUserCommand)
    {
        UpdatedAppUserResponse response = await Mediator.Send(updateAppUserCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAppUserResponse response = await Mediator.Send(new DeleteAppUserCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAppUserResponse response = await Mediator.Send(new GetByIdAppUserQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAppUserQuery getListAppUserQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAppUserListItemDto> response = await Mediator.Send(getListAppUserQuery);
        return Ok(response);
    }
}