using WebAppMVC.Data.Interface;
using WebAppMVC.Data.Repository;
using WebAppMVC.Service.Implement;
using WebAppMVC.Service.Interface;

namespace WebAppMVC.Extentions
{
    public static class Extentions 
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //DI Service
            //services.AddTransient<IUserService, UserService>();

            ////DI Repository
            services.AddTransient<IUserRepo, UserRepo>();
            return services;
        }
    }
}
