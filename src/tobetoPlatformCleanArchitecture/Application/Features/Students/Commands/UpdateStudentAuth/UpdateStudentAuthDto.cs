using Core.Application.Dtos;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Commands.UpdateStudentAuth;
public class UpdateStudentAuthDto : IDto
{
    public int UserId { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmNewPassword { get; set; }
    
}
