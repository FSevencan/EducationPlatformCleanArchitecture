using Application.Features.ClassRooms.Commands.Create;
using Application.Features.ClassRooms.Commands.Delete;
using Application.Features.ClassRooms.Commands.Update;
using Application.Features.ClassRooms.Queries.GetById;
using Application.Features.ClassRooms.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassRoomsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateClassRoomCommand createClassRoomCommand)
    {
        CreatedClassRoomResponse response = await Mediator.Send(createClassRoomCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateClassRoomCommand updateClassRoomCommand)
    {
        UpdatedClassRoomResponse response = await Mediator.Send(updateClassRoomCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedClassRoomResponse response = await Mediator.Send(new DeleteClassRoomCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdClassRoomResponse response = await Mediator.Send(new GetByIdClassRoomQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListClassRoomQuery getListClassRoomQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListClassRoomListItemDto> response = await Mediator.Send(getListClassRoomQuery);
        return Ok(response);
    }
}