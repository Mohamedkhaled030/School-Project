using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shcool.Core.Bases;

using Shcool.Data.Entity.Identity;
using Shcool.Service.Abstruct;

namespace Shcool.Core.Featuers.ApplicationUser.Command.Model
{
    public class UserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
                                                     , IRequestHandler<UpdateUserComand, Response<string>>
                                                     , IRequestHandler<DeleteUserCommand, Response<string>>
                                                     , IRequestHandler<ChangePasswordCommand, Response<string>>
    {
        private readonly IMapper _Mapper;
        private readonly UserManager<User> _UserManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailsService _emailsService;
        private readonly IApplicationUserService _applicationUserService;

        public UserCommandHandler(IMapper mapper, UserManager<User> userManager, IHttpContextAccessor httpContext, IEmailsService emailsService, IApplicationUserService applicationUserService)
        {
            _Mapper = mapper;
            _UserManager = userManager;
            _httpContextAccessor = httpContext;
            _emailsService = emailsService;
            this._applicationUserService = applicationUserService;
        }
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {


            //Mapping
            var IdentityUserMapping = _Mapper.Map<User>(request);
            //Create
            var createResult = await _applicationUserService.AddUser(IdentityUserMapping, request.Password);
            switch (createResult)
            {
                case "TheEmailIsExist": return BadRequest<string>("Email Is Exist");
                case "TheNameIsExist": return BadRequest<string>("Name Is Exist");
                case "ErrorInCreateUser": return BadRequest<string>("Faild To Add User");
                case "Failed": return BadRequest<string>("Faild try to Register");
                case "Success": return Success<string>("opration done");
                default: return BadRequest<string>(createResult);
            }
        }

        public async Task<Response<string>> Handle(UpdateUserComand request, CancellationToken cancellationToken)
        {
            var oldUser = await _UserManager.FindByIdAsync(request.Id);
            if (oldUser == null) return NotFound<string>("User Not Found");

            var mappingNewUser = _Mapper.Map(request, oldUser);
            var result = await _UserManager.UpdateAsync(mappingNewUser);
            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);

            return Success("");

        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _UserManager.FindByIdAsync(request.Id);
            if (user == null) return NotFound<string>("User Not Found");
            var result = await _UserManager.DeleteAsync(user);
            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            return Deleted<string>();
        }

        public async Task<Response<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _UserManager.FindByIdAsync(request.Id);
            if (user == null) return NotFound<string>("User Not Found");

            var result = await _UserManager.ChangePasswordAsync(user, request.CurruntPassword, request.NewPassword);

            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);

            return Success("Change Password Successfully");

        }
    }
}
