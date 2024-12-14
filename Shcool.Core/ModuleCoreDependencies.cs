

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Shcool.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            //Configration Of Mediatot
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //Configration Of AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }

    }
}
