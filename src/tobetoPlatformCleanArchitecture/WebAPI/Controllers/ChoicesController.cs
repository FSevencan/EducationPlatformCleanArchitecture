using Application.Features.Choices.Commands.Create;
using Application.Features.Choices.Commands.Delete;
using Application.Features.Choices.Commands.Update;
using Application.Features.Choices.Queries.GetById;
using Application.Features.Choices.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChoicesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateChoiceCommand createChoiceCommand)
    {
        CreatedChoiceResponse response = await Mediator.Send(createChoiceCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateChoiceCommand updateChoiceCommand)
    {
        UpdatedChoiceResponse response = await Mediator.Send(updateChoiceCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedChoiceResponse response = await Mediator.Send(new DeleteChoiceCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdChoiceResponse response = await Mediator.Send(new GetByIdChoiceQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListChoiceQuery getListChoiceQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListChoiceListItemDto> response = await Mediator.Send(getListChoiceQuery);
        return Ok(response);
    }
}