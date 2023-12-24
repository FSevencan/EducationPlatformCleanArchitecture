using Application.Features.ClassRoomTypes.Commands.Create;
using Application.Features.ClassRoomTypes.Commands.Delete;
using Application.Features.ClassRoomTypes.Commands.Update;
using Application.Features.ClassRoomTypes.Queries.GetById;
using Application.Features.ClassRoomTypes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassRoomTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateClassRoomTypeCommand createClassRoomTypeCommand)
    {
        CreatedClassRoomTypeResponse response = await Mediator.Send(createClassRoomTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateClassRoomTypeCommand updateClassRoomTypeCommand)
    {
        UpdatedClassRoomTypeResponse response = await Mediator.Send(updateClassRoomTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedClassRoomTypeResponse response = await Mediator.Send(new DeleteClassRoomTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdClassRoomTypeResponse response = await Mediator.Send(new GetByIdClassRoomTypeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListClassRoomTypeQuery getListClassRoomTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListClassRoomTypeListItemDto> response = await Mediator.Send(getListClassRoomTypeQuery);
        return Ok(response);
    }
}