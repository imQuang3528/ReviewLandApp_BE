using IRepository.ICateReviewRep;
using IRepository.IListLandRep;
using IRepository.IUserRepository;
using IService.ICateReviewSer;
using IService.IListLandSer;
using IService.IUserSer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Repository.CateReviewRep;
using Repository.ListLandRep;
using Repository.UserRepository;
using Service.CateReviewSer;
using Service.ListLandSer;
using Service.UserSer;
using Utility;

namespace ReviewLandApp.Helpers
{
    public static class CustomDI
    {
        /// <summary>
        /// Đăng kí các dịch vụ
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ImplementDependentInject(this IServiceCollection services)
        {
            services.AddTransient<ICateReviewSer, CategoryReviewSer>();
            services.AddTransient<ICateReviewRep, CategoryReviewRep>();
            services.AddTransient<IListLandRep, ListLandRep>();
            services.AddTransient<IListLandSer, ListLandSer>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUtils, Utils>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }

    }
}
