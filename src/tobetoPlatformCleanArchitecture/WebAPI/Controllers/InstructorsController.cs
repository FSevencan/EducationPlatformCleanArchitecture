using Application.Features.Instructors.Commands.Create;
using Application.Features.Instructors.Commands.Delete;
using Application.Features.Instructors.Commands.Update;
using Application.Features.Instructors.Commands.UpdateInstructorAuth;
using Application.Features.Instructors.Queries.GetById;
using Application.Features.Instructors.Queries.GetList;
using Application.Features.Students.Commands.UpdateStudentAuth;
using Application.Features.Students.Queries.GetById;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstructorsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateInstructorCommand createInstructorCommand)
    {
        CreatedInstructorResponse response = await Mediator.Send(createInstructorCommand);

        return Created(uri: "", response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateInstructorCommand updateInstructorCommand)
    {
        UpdatedInstructorResponse response = await Mediator.Send(updateInstructorCommand);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInstructorById([FromRoute] int id)
    {
        GetByIdInstructorResponse response = await Mediator.Send(new GetInstructorByIdQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("by-instructor/{userId}")]
    public async Task<IActionResult> GetInstructorByUserId([FromRoute] int userId)
    {
        GetByIdInstructorResponse response = await Mediator.Send(new GetByInstructorUserIdQuery { UserId = userId });
        return Ok(response);
    }
    [HttpGet("instructorlock/{userId}")]
    public async Task<IActionResult> GetBySectionIdForUserId([FromRoute] int userId)
    {

        GetByIdInstructorLockResponse response = await Mediator.Send(new GetByInstructorLockUserIdQuery { UserId = userId });
        return Ok(response);
    }
    

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListInstructorQuery getListInstructorQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListInstructorListItemDto> response = await Mediator.Send(getListInstructorQuery);
        return Ok(response);
    }

    [HttpPost("update-password")]
    public async Task<IActionResult> UpdatePassword([FromBody] UpdateInstructorAuthDto updateInstructorAuthDto )
    {
        var updateInstructorAuthCommand = new UpdateInstructorAuthCommand { UpdateInstructorAuthDto = updateInstructorAuthDto };
        var response = await Mediator.Send(updateInstructorAuthCommand);
        return Ok(response);
    }
}