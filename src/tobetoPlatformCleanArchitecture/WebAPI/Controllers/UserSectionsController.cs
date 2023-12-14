using Application.Features.UserSections.Commands.Create;
using Application.Features.UserSections.Commands.Delete;
using Application.Features.UserSections.Commands.Update;
using Application.Features.UserSections.Queries.GetById;
using Application.Features.UserSections.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserSectionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserSectionCommand createUserSectionCommand)
    {
        CreatedUserSectionResponse response = await Mediator.Send(createUserSectionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserSectionCommand updateUserSectionCommand)
    {
        UpdatedUserSectionResponse response = await Mediator.Send(updateUserSectionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedUserSectionResponse response = await Mediator.Send(new DeleteUserSectionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdUserSectionResponse response = await Mediator.Send(new GetByIdUserSectionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserSectionQuery getListUserSectionQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserSectionListItemDto> response = await Mediator.Send(getListUserSectionQuery);
        return Ok(response);
    }
}