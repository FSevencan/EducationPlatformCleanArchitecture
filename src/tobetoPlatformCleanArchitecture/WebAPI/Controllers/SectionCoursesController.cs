using Application.Features.SectionCourses.Commands.Create;
using Application.Features.SectionCourses.Commands.Delete;
using Application.Features.SectionCourses.Commands.Update;
using Application.Features.SectionCourses.Queries.GetById;
using Application.Features.SectionCourses.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SectionCoursesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSectionCourseCommand createSectionCourseCommand)
    {
        CreatedSectionCourseResponse response = await Mediator.Send(createSectionCourseCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSectionCourseCommand updateSectionCourseCommand)
    {
        UpdatedSectionCourseResponse response = await Mediator.Send(updateSectionCourseCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedSectionCourseResponse response = await Mediator.Send(new DeleteSectionCourseCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSectionCourseResponse response = await Mediator.Send(new GetByIdSectionCourseQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSectionCourseQuery getListSectionCourseQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSectionCourseListItemDto> response = await Mediator.Send(getListSectionCourseQuery);
        return Ok(response);
    }
}