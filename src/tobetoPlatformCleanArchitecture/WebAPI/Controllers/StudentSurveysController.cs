using Application.Features.StudentSurveys.Commands.Create;
using Application.Features.StudentSurveys.Commands.Delete;
using Application.Features.StudentSurveys.Commands.Update;
using Application.Features.StudentSurveys.Queries.GetById;
using Application.Features.StudentSurveys.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentSurveysController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStudentSurveyCommand createStudentSurveyCommand)
    {
        CreatedStudentSurveyResponse response = await Mediator.Send(createStudentSurveyCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStudentSurveyCommand updateStudentSurveyCommand)
    {
        UpdatedStudentSurveyResponse response = await Mediator.Send(updateStudentSurveyCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedStudentSurveyResponse response = await Mediator.Send(new DeleteStudentSurveyCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdStudentSurveyResponse response = await Mediator.Send(new GetByIdStudentSurveyQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStudentSurveyQuery getListStudentSurveyQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStudentSurveyListItemDto> response = await Mediator.Send(getListStudentSurveyQuery);
        return Ok(response);
    }
}