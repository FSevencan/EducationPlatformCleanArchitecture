using Application.Features.Students.Commands.Create;
using Application.Features.Students.Commands.Delete;
using Application.Features.Students.Commands.Update;
using Application.Features.Students.Queries.GetById;
using Application.Features.Students.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStudentCommand createStudentCommand)
    {
        CreatedStudentResponse response = await Mediator.Send(createStudentCommand);

        return Created(uri: "", response);
    }

    [HttpPut ("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateStudentCommand updateStudentCommand)
    {
        UpdatedStudentResponse response = await Mediator.Send(updateStudentCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedStudentResponse response = await Mediator.Send(new DeleteStudentCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("by-student/{userId}")]
    public async Task<IActionResult> GetById([FromRoute] int userId)
    {
        GetByIdStudentResponse response = await Mediator.Send(new GetByIdStudentQuery { UserId = userId });
        return Ok(response);
    }
    [HttpGet("studentlock/{userId}")]
    public async Task<IActionResult> GetBySectionIdForUserId([FromRoute] int userId)
    {
        GetByUserIdStudentLockResponse response = await Mediator.Send(new GetByUserIdStudentLockQuery { UserId = userId });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStudentQuery getListStudentQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStudentListItemDto> response = await Mediator.Send(getListStudentQuery);
        return Ok(response);
    }
}