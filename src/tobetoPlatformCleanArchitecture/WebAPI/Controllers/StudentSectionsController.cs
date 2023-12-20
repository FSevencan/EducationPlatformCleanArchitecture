using Application.Features.StudentSections.Commands.Create;
using Application.Features.StudentSections.Commands.Delete;
using Application.Features.StudentSections.Commands.Update;
using Application.Features.StudentSections.Queries.GetById;
using Application.Features.StudentSections.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentSectionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStudentSectionCommand createStudentSectionCommand)
    {
        CreatedStudentSectionResponse response = await Mediator.Send(createStudentSectionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStudentSectionCommand updateStudentSectionCommand)
    {
        UpdatedStudentSectionResponse response = await Mediator.Send(updateStudentSectionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedStudentSectionResponse response = await Mediator.Send(new DeleteStudentSectionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdStudentSectionResponse response = await Mediator.Send(new GetByIdStudentSectionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStudentSectionQuery getListStudentSectionQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStudentSectionListItemDto> response = await Mediator.Send(getListStudentSectionQuery);
        return Ok(response);
    }
}