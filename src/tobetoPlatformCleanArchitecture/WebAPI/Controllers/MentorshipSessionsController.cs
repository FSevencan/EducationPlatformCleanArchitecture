using Application.Features.MentorshipSessions.Commands.Create;
using Application.Features.MentorshipSessions.Commands.Delete;
using Application.Features.MentorshipSessions.Commands.Update;
using Application.Features.MentorshipSessions.Queries.GetById;
using Application.Features.MentorshipSessions.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MentorshipSessionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMentorshipSessionCommand createMentorshipSessionCommand)
    {
        CreatedMentorshipSessionResponse response = await Mediator.Send(createMentorshipSessionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMentorshipSessionCommand updateMentorshipSessionCommand)
    {
        UpdatedMentorshipSessionResponse response = await Mediator.Send(updateMentorshipSessionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMentorshipSessionResponse response = await Mediator.Send(new DeleteMentorshipSessionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMentorshipSessionResponse response = await Mediator.Send(new GetByIdMentorshipSessionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMentorshipSessionQuery getListMentorshipSessionQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMentorshipSessionListItemDto> response = await Mediator.Send(getListMentorshipSessionQuery);
        return Ok(response);
    }
}