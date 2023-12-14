using Application.Features.SectionInstructors.Commands.Create;
using Application.Features.SectionInstructors.Commands.Delete;
using Application.Features.SectionInstructors.Commands.Update;
using Application.Features.SectionInstructors.Queries.GetById;
using Application.Features.SectionInstructors.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SectionInstructorsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSectionInstructorCommand createSectionInstructorCommand)
    {
        CreatedSectionInstructorResponse response = await Mediator.Send(createSectionInstructorCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSectionInstructorCommand updateSectionInstructorCommand)
    {
        UpdatedSectionInstructorResponse response = await Mediator.Send(updateSectionInstructorCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedSectionInstructorResponse response = await Mediator.Send(new DeleteSectionInstructorCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSectionInstructorResponse response = await Mediator.Send(new GetByIdSectionInstructorQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSectionInstructorQuery getListSectionInstructorQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSectionInstructorListItemDto> response = await Mediator.Send(getListSectionInstructorQuery);
        return Ok(response);
    }
}