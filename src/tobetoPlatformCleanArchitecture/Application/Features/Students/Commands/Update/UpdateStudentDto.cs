using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Commands.Update;
public class UpdateStudentDto:IDto
{
    public int Id { get; set; }
    public int? ProvinceId { get; set; }
    public int? DistrictId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Biography { get; set; }
    public string? GithubUrl { get; set; }
    public string? LinkedinUrl { get; set; }
  
}
