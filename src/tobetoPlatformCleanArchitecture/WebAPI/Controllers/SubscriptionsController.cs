using Application.Features.Subscriptions.Commands.Create;
using Application.Features.Subscriptions.Commands.Delete;
using Application.Features.Subscriptions.Commands.Update;
using Application.Features.Subscriptions.Queries.GetById;
using Application.Features.Subscriptions.Queries.GetList;
using Application.Features.Subscriptions.Queries.GetSubscriptionsByUserId;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscriptionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSubscriptionCommand createSubscriptionCommand)
    {
        CreatedSubscriptionResponse response = await Mediator.Send(createSubscriptionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSubscriptionCommand updateSubscriptionCommand)
    {
        UpdatedSubscriptionResponse response = await Mediator.Send(updateSubscriptionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedSubscriptionResponse response = await Mediator.Send(new DeleteSubscriptionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSubscriptionResponse response = await Mediator.Send(new GetByIdSubscriptionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("users/{userId}/subscription")]
    public async Task<IActionResult> GetSubscriptionByUserId([FromRoute] int userId)
    {
        GetSubscriptionByUserIdResponse response = await Mediator.Send(new GetSubscriptionByUserIdQuery { UserId = userId });
        return Ok(response);
    }


    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSubscriptionQuery getListSubscriptionQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSubscriptionListItemDto> response = await Mediator.Send(getListSubscriptionQuery);
        return Ok(response);
    }
}