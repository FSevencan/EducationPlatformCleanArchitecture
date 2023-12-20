using Application.Features.StudentClassRooms.Commands.Create;
using Application.Features.StudentClassRooms.Commands.Delete;
using Application.Features.StudentClassRooms.Commands.Update;
using Application.Features.StudentClassRooms.Queries.GetById;
using Application.Features.StudentClassRooms.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentClassRoomsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStudentClassRoomCommand createStudentClassRoomCommand)
    {
        CreatedStudentClassRoomResponse response = await Mediator.Send(createStudentClassRoomCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStudentClassRoomCommand updateStudentClassRoomCommand)
    {
        UpdatedStudentClassRoomResponse response = await Mediator.Send(updateStudentClassRoomCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedStudentClassRoomResponse response = await Mediator.Send(new DeleteStudentClassRoomCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdStudentClassRoomResponse response = await Mediator.Send(new GetByIdStudentClassRoomQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStudentClassRoomQuery getListStudentClassRoomQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStudentClassRoomListItemDto> response = await Mediator.Send(getListStudentClassRoomQuery);
        return Ok(response);
    }
}