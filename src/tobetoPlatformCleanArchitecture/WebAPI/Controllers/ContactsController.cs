using Application.Features.Contacts.Commands.Create;
using Application.Features.Contacts.Commands.Delete;
using Application.Features.Contacts.Commands.Update;
using Application.Features.Contacts.Queries.GetById;
using Application.Features.Contacts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateContactCommand createContactCommand)
    {
        CreatedContactResponse response = await Mediator.Send(createContactCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateContactCommand updateContactCommand)
    {
        UpdatedContactResponse response = await Mediator.Send(updateContactCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedContactResponse response = await Mediator.Send(new DeleteContactCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdContactResponse response = await Mediator.Send(new GetByIdContactQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListContactQuery getListContactQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListContactListItemDto> response = await Mediator.Send(getListContactQuery);
        return Ok(response);
    }
}