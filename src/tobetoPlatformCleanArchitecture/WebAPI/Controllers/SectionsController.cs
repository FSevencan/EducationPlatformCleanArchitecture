using Application.Features.Sections.Commands.Create;
using Application.Features.Sections.Commands.Delete;
using Application.Features.Sections.Commands.Update;
using Application.Features.Sections.Queries.GetById;
using Application.Features.Sections.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SectionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSectionCommand createSectionCommand)
    {
        CreatedSectionResponse response = await Mediator.Send(createSectionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSectionCommand updateSectionCommand)
    {
        UpdatedSectionResponse response = await Mediator.Send(updateSectionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedSectionResponse response = await Mediator.Send(new DeleteSectionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSectionResponse response = await Mediator.Send(new GetByIdSectionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSectionQuery getListSectionQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSectionListItemDto> response = await Mediator.Send(getListSectionQuery);
        return Ok(response);
    }

    [HttpGet("by-category/{categoryId}")] // eklendi
    public async Task<IActionResult> GetListByCategory([FromRoute] Guid categoryId, [FromQuery] PageRequest pageRequest)
    {
        GetListSectionQuery getListSectionQuery = new() { PageRequest = pageRequest, CategoryId = categoryId };
        GetListResponse<GetListSectionListItemDto> response = await Mediator.Send(getListSectionQuery);
        return Ok(response);
    }
}