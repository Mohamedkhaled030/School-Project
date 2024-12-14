using Microsoft.Extensions.DependencyInjection;
using Shcool.Data.Entity.Views;
using Shcool.Infrustructure.Abstruct;
using Shcool.Infrustructure.Abstruct.Function;
using Shcool.Infrustructure.Abstruct.Procdueres;
using Shcool.Infrustructure.Abstruct.Views;
using Shcool.Infrustructure.InfrustructurBase;
using Shcool.Infrustructure.Repository;
using Shcool.Infrustructure.Repository.Function;
using Shcool.Infrustructure.Repository.Procdueres;
using Shcool.Infrustructure.Repository.Views;

namespace Shcool.Infrustructure
{
    public static class ModuleInfrustructureDependencies
    {
        public static IServiceCollection AddInfrustructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<ISubjectRepositry, SubjectRepository>();
            services.AddTransient<IInstractourRepository, InstractourRepository>();
            services.AddTransient<IInstructorFunctionsRepository, InstructorFunctionsRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IViewDepartmentRepository<ViewDepartment>, ViewDepartmentRepository>();
            services.AddTransient<IDepartmentStudenCountProcRepository, DepartmentStudenCountProcRepository>();

            return services;
        }
    }
}
