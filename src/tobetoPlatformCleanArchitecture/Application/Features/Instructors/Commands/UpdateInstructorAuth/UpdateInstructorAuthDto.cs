using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Instructors.Commands.UpdateInstructorAuth;
public class UpdateInstructorAuthDto : IDto
{
    public int UserId { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmNewPassword { get; set; }
}
