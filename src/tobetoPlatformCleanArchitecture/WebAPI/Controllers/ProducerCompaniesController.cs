using Application.Features.ProducerCompanies.Commands.Create;
using Application.Features.ProducerCompanies.Commands.Delete;
using Application.Features.ProducerCompanies.Commands.Update;
using Application.Features.ProducerCompanies.Queries.GetById;
using Application.Features.ProducerCompanies.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProducerCompaniesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProducerCompanyCommand createProducerCompanyCommand)
    {
        CreatedProducerCompanyResponse response = await Mediator.Send(createProducerCompanyCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProducerCompanyCommand updateProducerCompanyCommand)
    {
        UpdatedProducerCompanyResponse response = await Mediator.Send(updateProducerCompanyCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedProducerCompanyResponse response = await Mediator.Send(new DeleteProducerCompanyCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdProducerCompanyResponse response = await Mediator.Send(new GetByIdProducerCompanyQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProducerCompanyQuery getListProducerCompanyQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProducerCompanyListItemDto> response = await Mediator.Send(getListProducerCompanyQuery);
        return Ok(response);
    }
}