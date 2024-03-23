using Application.Features.Auth.Commands.RevokeToken;
using Application.Features.Auth.Commands.VerifyEmailAuthenticator;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.Auth.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RefreshToken, RevokedTokenResponse>().ReverseMap();
   

    }
}
