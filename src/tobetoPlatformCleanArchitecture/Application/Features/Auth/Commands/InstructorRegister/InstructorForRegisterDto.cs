using Core.Application.Dtos;
using System;
namespace Application.Features.Auth.Commands.InstructorRegister
{
    public class InstructorForRegisterDto : IDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

    }
}

