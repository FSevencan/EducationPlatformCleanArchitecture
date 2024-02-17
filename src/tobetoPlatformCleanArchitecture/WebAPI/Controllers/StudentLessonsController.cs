using Application.Features.StudentLessons.Commands.Create;
using Application.Features.StudentLessons.Commands.Delete;
using Application.Features.StudentLessons.Commands.Update;
using Application.Features.StudentLessons.Queries.GetById;
using Application.Features.StudentLessons.Queries.GetCompletedLessonsByStudent;
using Application.Features.StudentLessons.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentLessonsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStudentLessonCommand createStudentLessonCommand)
    {
        CreatedStudentLessonResponse response = await Mediator.Send(createStudentLessonCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStudentLessonCommand updateStudentLessonCommand)
    {
        UpdatedStudentLessonResponse response = await Mediator.Send(updateStudentLessonCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedStudentLessonResponse response = await Mediator.Send(new DeleteStudentLessonCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdStudentLessonResponse response = await Mediator.Send(new GetByIdStudentLessonQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStudentLessonQuery getListStudentLessonQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStudentLessonListItemDto> response = await Mediator.Send(getListStudentLessonQuery);
        return Ok(response);
    }

    [HttpGet("GetCompletedLessons")]
    public async Task<IActionResult> GetCompletedLessonsByStudentId([FromQuery] int userId)
    {
        
        GetCompletedLessonsByStudentIdQuery query = new GetCompletedLessonsByStudentIdQuery { UserId = userId };

        List<GetCompletedLessonDto> response = await Mediator.Send(query);
        return Ok(response);
    }

}