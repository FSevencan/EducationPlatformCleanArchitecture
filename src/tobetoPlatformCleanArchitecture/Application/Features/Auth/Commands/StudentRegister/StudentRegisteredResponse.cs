using Core.Application.Responses;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.StudentRegister;

public class StudentRegisteredResponse : IResponse
{
    public AccessToken AccessToken { get; set; }
    public Core.Security.Entities.RefreshToken RefreshToken { get; set; }

    public StudentRegisteredResponse()
    {
        AccessToken = null!;
        RefreshToken = null!;
    }

    public StudentRegisteredResponse(AccessToken accessToken, Core.Security.Entities.RefreshToken refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }
}

