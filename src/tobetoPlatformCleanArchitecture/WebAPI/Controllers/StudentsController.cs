using Application.Features.Students.Commands.Create;
using Application.Features.Students.Commands.Delete;
using Application.Features.Students.Commands.Update;
using Application.Features.Students.Commands.UpdateStudentAuth;
using Application.Features.Students.Queries.GetById;
using Application.Features.Students.Queries.GetBySection;
using Application.Features.Students.Queries.GetList;
using Application.Features.Students.Queries.GetListCertificateByUserId;
using Application.Features.Students.Queries.GetListExamByUserId;
using Application.Features.Students.Queries.GetListSkillByUserId;
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

    [HttpPut("Update")]
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
    [HttpGet("studentsections/{userId}")]
    public async Task<IActionResult> GetBySection([FromRoute] int userId)
    {
        GetBySectionStudentResponse response = await Mediator.Send(new GetBySectionStudentQuery { UserId = userId });
        return Ok(response);
    }
    [HttpGet("studentlock/{userId}")]
    public async Task<IActionResult> GetBySectionIdForUserId([FromRoute] int userId)
    {
        GetByUserIdStudentLockResponse response = await Mediator.Send(new GetByUserIdStudentLockQuery { UserId = userId });
        return Ok(response);
    }

   
    [HttpGet("skills/{userId}")]
    public async Task<IActionResult> GetSkillsByUserId([FromRoute] int userId)
    {
        GetListSkillByUserIdResponse response = await Mediator.Send(new GetListSkillByUserIdQuery { UserId = userId });
        return Ok(response);
    }
   
    [HttpGet("exams/{userId}")]
    public async Task<IActionResult> GetExamsByUserId([FromRoute] int userId)
    {
        GetListExamByUserIdResponse response = await Mediator.Send(new GetListExamByUserIdQuery { UserId = userId });
        return Ok(response);
    }

    [HttpGet("certificates/{userId}")]
    public async Task<IActionResult> GetCertificatesByUserId([FromRoute] int userId)
    {
        GetListCertificateByUserIdResponse response = await Mediator.Send(new GetListCertificateByUserIdQuery { UserId = userId });
        return Ok(response);
    }


    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStudentQuery getListStudentQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStudentListItemDto> response = await Mediator.Send(getListStudentQuery);
        return Ok(response);
    }

    [HttpPost("update-password")]
    public async Task<IActionResult> UpdatePassword([FromBody] UpdateStudentAuthDto updateStudentAuthDto)
    {
        var updateStudentAuthCommand = new UpdateStudentAuthCommand { UpdateStudentAuthDto = updateStudentAuthDto };
        var response = await Mediator.Send(updateStudentAuthCommand);
        return Ok(response);
    }

}