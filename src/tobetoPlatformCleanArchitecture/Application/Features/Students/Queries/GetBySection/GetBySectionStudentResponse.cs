using Application.Features.Certificates.Queries.GetList;
using Application.Features.Sections.Queries.GetList;
using Application.Features.StudentClassRooms.Queries.GetById;
using Application.Features.Students.Queries.GetById.Dtos;
using Application.Features.StudentSkills.Queries.GetList;

using Application.Features.Surveys.Queries.GetList;
using Core.Application.Responses;
using Core.Security.Entities;

namespace Application.Features.Students.Queries.GetBySection;

public class GetBySectionStudentResponse : IResponse
{
    public ICollection<SectionStudentDto> Sections { get; set; }
}