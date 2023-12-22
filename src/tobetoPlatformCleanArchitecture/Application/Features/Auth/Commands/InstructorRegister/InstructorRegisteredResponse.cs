using Core.Application.Responses;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.InstructorRegister;
public class InstructorRegisteredResponse : IResponse
{
    public AccessToken AccessToken { get; set; }
    public Core.Security.Entities.RefreshToken RefreshToken { get; set; }

    public InstructorRegisteredResponse()
    {
        AccessToken = null!;
        RefreshToken = null!;
    }

    public InstructorRegisteredResponse(AccessToken accessToken, Core.Security.Entities.RefreshToken refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }
}




