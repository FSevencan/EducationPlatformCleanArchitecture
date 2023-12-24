using Application.Features.ClassRoomTypeSections.Commands.Create;
using Application.Features.ClassRoomTypeSections.Commands.Delete;
using Application.Features.ClassRoomTypeSections.Commands.Update;
using Application.Features.ClassRoomTypeSections.Queries.GetById;
using Application.Features.ClassRoomTypeSections.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassRoomTypeSectionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateClassRoomTypeSectionCommand createClassRoomTypeSectionCommand)
    {
        CreatedClassRoomTypeSectionResponse response = await Mediator.Send(createClassRoomTypeSectionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateClassRoomTypeSectionCommand updateClassRoomTypeSectionCommand)
    {
        UpdatedClassRoomTypeSectionResponse response = await Mediator.Send(updateClassRoomTypeSectionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedClassRoomTypeSectionResponse response = await Mediator.Send(new DeleteClassRoomTypeSectionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdClassRoomTypeSectionResponse response = await Mediator.Send(new GetByIdClassRoomTypeSectionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListClassRoomTypeSectionQuery getListClassRoomTypeSectionQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListClassRoomTypeSectionListItemDto> response = await Mediator.Send(getListClassRoomTypeSectionQuery);
        return Ok(response);
    }
}