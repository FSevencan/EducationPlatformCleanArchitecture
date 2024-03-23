using Application.Features.CampusEncounters.Commands.Create;
using Application.Features.CampusEncounters.Commands.Delete;
using Application.Features.CampusEncounters.Commands.Update;
using Application.Features.CampusEncounters.Queries.GetById;
using Application.Features.CampusEncounters.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CampusEncountersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCampusEncounterCommand createCampusEncounterCommand)
    {
        CreatedCampusEncounterResponse response = await Mediator.Send(createCampusEncounterCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCampusEncounterCommand updateCampusEncounterCommand)
    {
        UpdatedCampusEncounterResponse response = await Mediator.Send(updateCampusEncounterCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedCampusEncounterResponse response = await Mediator.Send(new DeleteCampusEncounterCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCampusEncounterResponse response = await Mediator.Send(new GetByIdCampusEncounterQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCampusEncounterQuery getListCampusEncounterQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCampusEncounterListItemDto> response = await Mediator.Send(getListCampusEncounterQuery);
        return Ok(response);
    }
}