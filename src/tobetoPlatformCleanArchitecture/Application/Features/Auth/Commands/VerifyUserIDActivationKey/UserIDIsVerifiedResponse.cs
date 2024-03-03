namespace Application.Features.Auth.Commands.VerifyEmailAuthenticator;
using Core.Application.Responses;

public class UserIDIsVerifiedResponse : IResponse
{

    public bool IsVerified { get; set; }

}


