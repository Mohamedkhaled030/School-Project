using Microsoft.Extensions.DependencyInjection;
using Shcool.Data.Entity.Views;
using Shcool.Infrustructure.Abstruct.Views;
using Shcool.Infrustructure.Repository.Views;
using Shcool.Service.Abstruct;
using Shcool.Service.AuthSevices.Implementatin;
using Shcool.Service.AuthSevices.interfaces;
using Shcool.Service.Implementations;
namespace Shcool.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IstudentServices, StudentService>();
            services.AddTransient<IDepartmentServices, DepartmentServies>();
            services.AddTransient<IAuthenticationServices, AuthenticationServices>();
            services.AddTransient<IAuthorizationServies, AuthorizationServies>();
            services.AddTransient<IEmailsService, EmailsServer>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<ICurrentUsersServices, CurrentUsersServices>();
            services.AddTransient<IViewDepartmentRepository<ViewDepartment>, ViewDepartmentRepository>();
            services.AddTransient<IInstractourServices, InstractourServices>();
            services.AddTransient<IformServices, FileService>();

            return services;
        }

    }
}
