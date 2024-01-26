using Application.Features.Certificates.Queries.GetList;
using Application.Features.Sections.Queries.GetList;
using Application.Features.StudentClassRooms.Queries.GetById;
using Application.Features.Students.Queries.GetById.Dtos;
using Application.Features.StudentSkills.Queries.GetList;

using Application.Features.Surveys.Queries.GetList;
using Core.Application.Responses;
using Core.Security.Entities;

namespace Application.Features.Students.Queries.GetById;

public class GetByIdStudentResponse : IResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Biography { get; set; }
    public string? GithubUrl { get; set; }
    public string? LinkedinUrl { get; set; }

    public List<GetStudentSectionListDto>? Sections { get; set; }
    public List<string>? ClassRoomNames { get; set; }
  
    public List<GetStudentSkillListDto>? Skills { get; set; }
    public List<GetStudentCertificateListDto>? Certificates { get; set; }

}