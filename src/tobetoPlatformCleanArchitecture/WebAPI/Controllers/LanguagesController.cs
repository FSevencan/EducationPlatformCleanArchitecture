using Application.Features.Languages.Commands.Create;
using Application.Features.Languages.Commands.Delete;
using Application.Features.Languages.Commands.Update;
using Application.Features.Languages.Queries.GetById;
using Application.Features.Languages.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
    {
        CreatedLanguageResponse response = await Mediator.Send(createLanguageCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLanguageCommand updateLanguageCommand)
    {
        UpdatedLanguageResponse response = await Mediator.Send(updateLanguageCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedLanguageResponse response = await Mediator.Send(new DeleteLanguageCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdLanguageResponse response = await Mediator.Send(new GetByIdLanguageQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLanguageQuery getListLanguageQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLanguageListItemDto> response = await Mediator.Send(getListLanguageQuery);
        return Ok(response);
    }
}