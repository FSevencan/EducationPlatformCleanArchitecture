using Application.Features.UserAnswers.Commands.Create;
using Application.Features.UserAnswers.Commands.Delete;
using Application.Features.UserAnswers.Commands.Update;
using Application.Features.UserAnswers.Queries.GetById;
using Application.Features.UserAnswers.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserAnswersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserAnswerCommand createUserAnswerCommand)
    {
        CreatedUserAnswerResponse response = await Mediator.Send(createUserAnswerCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserAnswerCommand updateUserAnswerCommand)
    {
        UpdatedUserAnswerResponse response = await Mediator.Send(updateUserAnswerCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedUserAnswerResponse response = await Mediator.Send(new DeleteUserAnswerCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdUserAnswerResponse response = await Mediator.Send(new GetByIdUserAnswerQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserAnswerQuery getListUserAnswerQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserAnswerListItemDto> response = await Mediator.Send(getListUserAnswerQuery);
        return Ok(response);
    }
}