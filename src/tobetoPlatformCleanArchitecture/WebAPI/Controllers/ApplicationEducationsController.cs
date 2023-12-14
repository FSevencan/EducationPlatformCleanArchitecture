using Application.Features.ApplicationEducations.Commands.Create;
using Application.Features.ApplicationEducations.Commands.Delete;
using Application.Features.ApplicationEducations.Commands.Update;
using Application.Features.ApplicationEducations.Queries.GetById;
using Application.Features.ApplicationEducations.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationEducationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateApplicationEducationCommand createApplicationEducationCommand)
    {
        CreatedApplicationEducationResponse response = await Mediator.Send(createApplicationEducationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateApplicationEducationCommand updateApplicationEducationCommand)
    {
        UpdatedApplicationEducationResponse response = await Mediator.Send(updateApplicationEducationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedApplicationEducationResponse response = await Mediator.Send(new DeleteApplicationEducationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdApplicationEducationResponse response = await Mediator.Send(new GetByIdApplicationEducationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListApplicationEducationQuery getListApplicationEducationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListApplicationEducationListItemDto> response = await Mediator.Send(getListApplicationEducationQuery);
        return Ok(response);
    }
}