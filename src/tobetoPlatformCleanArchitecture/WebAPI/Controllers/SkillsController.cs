using Application.Features.Skills.Commands.Create;
using Application.Features.Skills.Commands.Delete;
using Application.Features.Skills.Commands.Update;
using Application.Features.Skills.Queries.GetById;
using Application.Features.Skills.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SkillsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSkillCommand createSkillCommand)
    {
        CreatedSkillResponse response = await Mediator.Send(createSkillCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSkillCommand updateSkillCommand)
    {
        UpdatedSkillResponse response = await Mediator.Send(updateSkillCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedSkillResponse response = await Mediator.Send(new DeleteSkillCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSkillResponse response = await Mediator.Send(new GetByIdSkillQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSkillQuery getListSkillQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSkillListItemDto> response = await Mediator.Send(getListSkillQuery);
        return Ok(response);
    }
}