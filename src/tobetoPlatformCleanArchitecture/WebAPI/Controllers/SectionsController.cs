using Application.Features.Sections.Commands.Create;
using Application.Features.Sections.Commands.Delete;
using Application.Features.Sections.Commands.Update;
using Application.Features.Sections.Queries.GetById;
using Application.Features.Sections.Queries.GetList;
using Application.Features.Sections.Queries.GetSearchSections;
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

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] PageRequest pageRequest, [FromQuery] string searchTerm)
    {
        GetSearchSectionsQuery getSearchArticlesQuery = new()
        {
            PageRequest = pageRequest,
            SearchTerm = searchTerm
        };
        GetListResponse<GetSearchSectionListDto> response = await Mediator.Send(getSearchArticlesQuery);
        return Ok(response);
    }

}