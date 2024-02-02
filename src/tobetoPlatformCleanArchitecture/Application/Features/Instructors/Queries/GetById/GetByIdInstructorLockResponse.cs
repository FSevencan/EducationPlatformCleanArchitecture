using Application.Features.Sections.Queries.GetList;
using Application.Features.Students.Queries.GetById.Dtos;
using Core.Application.Responses;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Features.Instructors.Queries.GetById;

public class GetByIdInstructorLockResponse : IResponse
{
    public List<GetLockDto>? Sections { get; set; }

}