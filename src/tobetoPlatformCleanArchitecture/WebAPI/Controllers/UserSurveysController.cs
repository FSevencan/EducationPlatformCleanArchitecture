using Application.Features.UserSurveys.Commands.Create;
using Application.Features.UserSurveys.Commands.Delete;
using Application.Features.UserSurveys.Commands.Update;
using Application.Features.UserSurveys.Queries.GetById;
using Application.Features.UserSurveys.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserSurveysController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserSurveyCommand createUserSurveyCommand)
    {
        CreatedUserSurveyResponse response = await Mediator.Send(createUserSurveyCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserSurveyCommand updateUserSurveyCommand)
    {
        UpdatedUserSurveyResponse response = await Mediator.Send(updateUserSurveyCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedUserSurveyResponse response = await Mediator.Send(new DeleteUserSurveyCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdUserSurveyResponse response = await Mediator.Send(new GetByIdUserSurveyQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserSurveyQuery getListUserSurveyQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserSurveyListItemDto> response = await Mediator.Send(getListUserSurveyQuery);
        return Ok(response);
    }
}