using Application.Features.Provinces.Commands.Create;
using Application.Features.Provinces.Commands.Delete;
using Application.Features.Provinces.Commands.Update;
using Application.Features.Provinces.Queries.GetById;
using Application.Features.Provinces.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProvincesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProvinceCommand createProvinceCommand)
    {
        CreatedProvinceResponse response = await Mediator.Send(createProvinceCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProvinceCommand updateProvinceCommand)
    {
        UpdatedProvinceResponse response = await Mediator.Send(updateProvinceCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProvinceResponse response = await Mediator.Send(new DeleteProvinceCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProvinceResponse response = await Mediator.Send(new GetByIdProvinceQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProvinceQuery getListProvinceQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProvinceListItemDto> response = await Mediator.Send(getListProvinceQuery);
        return Ok(response);
    }
}