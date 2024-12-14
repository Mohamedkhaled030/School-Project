using MediatR;
using Microsoft.AspNetCore.Identity;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.Authantcation.Command.Model;
using Shcool.Data.Entity.Identity;
using Shcool.Data.Results;
using Shcool.Service.Abstruct;

namespace Shcool.Core.Featuers.Authantcation.Command.Handler
{
    public class AuthenticationCommandHandler : ResponseHandler, IRequestHandler<SigninCommand, Response<JwtAuthResult>>,
                                                                 IRequestHandler<AddRoleCommand, Response<JwtAuthResult>>,
                                                                 IRequestHandler<SendResetPasswordCommand, Response<string>>,
                                                                 IRequestHandler<ResetPasswordCommand, Response<string>>
                                                                 
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationServices _IAuthenticationServices;

        public AuthenticationCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, IAuthenticationServices authenticationServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _IAuthenticationServices = authenticationServices;
        }
        public async Task<Response<JwtAuthResult>> Handle(SigninCommand request, CancellationToken cancellationToken)
        {
            //Cheack if User is Exist or Not
            var user = await _userManager.FindByNameAsync(request.UserName);
            // if User Exist
            if (user == null) return NotFound<JwtAuthResult>("The User Name not Found");
            //try to sign in
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!signInResult.Succeeded) return BadRequest<JwtAuthResult>("Password InCorrect");
            //genrate token
            var accesstoken = await _IAuthenticationServices.GetJwTTokenAsync(user);

            return Success(accesstoken);

        }

        public async Task<Response<JwtAuthResult>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var JwtToken = _IAuthenticationServices.ReadJwtToken(request.AccessToken);
            var UserandExpirdate = await _IAuthenticationServices.ValidateDetalis(JwtToken, request.AccessToken, request.RefreshToken);
            switch (UserandExpirdate)
            {
                case ("AlgorithmsNotEqual", null): return Unauthorized<JwtAuthResult>("Algorithms Not Equal");
                case ("TokenisNotExpiare", null): return Unauthorized<JwtAuthResult>("Token is Not Expiare");
                case ("RefreshtokenisNotFound", null): return Unauthorized<JwtAuthResult>("Refresh token is Not Found");
                case ("RefreshTokenisExpiare", null): return Unauthorized<JwtAuthResult>("Refresh Token is Expiare");
            }
            var (userId, expirdate) = UserandExpirdate;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound<JwtAuthResult>("User Not Found");
            var result = await _IAuthenticationServices.GetRefreshTokenAsync(user, JwtToken, request.RefreshToken, expirdate);
            return Success(result);
        }

        public async Task<Response<string>> Handle(SendResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _IAuthenticationServices.SendResetPasswordCode(request.Email);
            return result switch
            {
                "UserNotFound" => BadRequest<string>("User Not Found"),
                "ErroreUpdateUser" => BadRequest<string>("Errore Update User"),
                "Faild" => BadRequest<string>("Wrong Hapin !Try Opration Again"),
                "Success" => Success<string>(""),
                _ => BadRequest<string>("Try Again Anather Time"),
            };
        }

        public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _IAuthenticationServices.ResetPasswordCode(request.Email,request.Password);
            return result switch
            {
                "UserNotFound" => BadRequest<string>("User Not Found"),
                
                "Faild" => BadRequest<string>("faild ! Try Agian leter"),
                "Success" => Success<string>(""),
                _ => BadRequest<string>("Try Again Anather Time"),
            };
        }
    }
}
