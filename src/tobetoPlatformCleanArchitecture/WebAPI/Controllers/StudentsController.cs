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

    [HttpPut]
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdStudentResponse response = await Mediator.Send(new GetByIdStudentQuery { UserId = id });
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