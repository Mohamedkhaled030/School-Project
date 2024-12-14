using MediatR;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.Authantcation.Query.Model;
using Shcool.Service.Abstruct;

namespace Shcool.Core.Featuers.Authantcation.Query.Handler
{
    public class AuthenticationQueryHandler : ResponseHandler, IRequestHandler<AutheiesUserQuery, Response<string>>,
                                                               IRequestHandler<ConfirmEmailQuery, Response<string>>,
                                                               IRequestHandler<ResetPasswordQuery, Response<string>>

    {

        private readonly IAuthenticationServices _IAuthenticationServices;

        public AuthenticationQueryHandler(IAuthenticationServices authenticationServices)
        {

            _IAuthenticationServices = authenticationServices;
        }

        public async Task<Response<string>> Handle(AutheiesUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _IAuthenticationServices.ValidateTokenAsync(request.AccessToken);
            if (result == "NotExpired")
                return Success(result);

            return Unauthorized<string>("Token is Expired");
        }

        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var confirmEmail = await _IAuthenticationServices.ConfirmEmail(request.userId, request.code);
            if (confirmEmail == "EroorConfirmEmail")
                return BadRequest<string>("Error When Confirm Email");
            return Success<string>("Confirm Email done");

        }

        public async Task<Response<string>> Handle(ResetPasswordQuery request, CancellationToken cancellationToken)
        {
            var result = await _IAuthenticationServices.ConfirmResetPasswordCode(request.Code, request.Email);
            return result switch
            {
                "UserNotFound" => BadRequest<string>("User Not Found"),
                "Faild" => BadRequest<string>("Invalid Code"),
                "Success" => Success<string>(""),
                _ => BadRequest<string>("Try Again Anather Time"),
            };
        }
    }
}