using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Instructors.Commands.Update;
public class UpdateInstructorDto:IDto
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string ImageUrl { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string About { get; set; }
    public string Title { get; set; }

    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}
