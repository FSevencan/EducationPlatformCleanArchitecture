using Application.Features.SectionAbouts.Commands.Create;
using Application.Features.SectionAbouts.Commands.Delete;
using Application.Features.SectionAbouts.Commands.Update;
using Application.Features.SectionAbouts.Queries.GetById;
using Application.Features.SectionAbouts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SectionAboutsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSectionAboutCommand createSectionAboutCommand)
    {
        CreatedSectionAboutResponse response = await Mediator.Send(createSectionAboutCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSectionAboutCommand updateSectionAboutCommand)
    {
        UpdatedSectionAboutResponse response = await Mediator.Send(updateSectionAboutCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedSectionAboutResponse response = await Mediator.Send(new DeleteSectionAboutCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSectionAboutResponse response = await Mediator.Send(new GetByIdSectionAboutQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSectionAboutQuery getListSectionAboutQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSectionAboutListItemDto> response = await Mediator.Send(getListSectionAboutQuery);
        return Ok(response);
    }
}