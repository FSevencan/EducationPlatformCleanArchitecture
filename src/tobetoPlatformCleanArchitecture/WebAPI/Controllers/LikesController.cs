using Application.Features.Likes.Commands.Create;
using Application.Features.Likes.Commands.Delete;
using Application.Features.Likes.Commands.Update;
using Application.Features.Likes.Queries.CheckLikeStatus;
using Application.Features.Likes.Queries.GetById;
using Application.Features.Likes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LikesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLikeCommand createLikeCommand)
    {
        CreatedLikeResponse response = await Mediator.Send(createLikeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLikeCommand updateLikeCommand)
    {
        UpdatedLikeResponse response = await Mediator.Send(updateLikeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedLikeResponse response = await Mediator.Send(new DeleteLikeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdLikeResponse response = await Mediator.Send(new GetByIdLikeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLikeQuery getListLikeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLikeListItemDto> response = await Mediator.Send(getListLikeQuery);
        return Ok(response);
    }

    [HttpGet("check-like-status")]
    public async Task<IActionResult> CheckLikeStatus([FromQuery] int userId, [FromQuery] Guid sectionId)
    {
        var query = new CheckLikeStatusQuery { UserId = userId, SectionId = sectionId };
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}