using IRepository.ICateReviewRep;
using IRepository.IListHomestayRep;
using IRepository.IListLandRep;
using IService.ICateReviewSer;
using IService.IDetailHomestaySer;
using IService.IListLandSer;
using Microsoft.Extensions.DependencyInjection;
using Repository.CateReviewRep;
using Repository.ListHomestayRep;
using Repository.ListLandRep;
using Service.CateReviewSer;
using Service.DetailHomestaySer;
using Service.ListLandSer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewLandApp.Helpers
{
    public class DI
    {
        public static IServiceCollection ConfigDI(IServiceCollection services)
        {
            services.AddScoped<ICateReviewRep, CategoryReviewRep>();
            services.AddScoped<ICateReviewSer, CategoryReviewSer>();
            services.AddScoped<IListLandRep, ListLandRep>();
            services.AddScoped<IListLandSer, ListLandSer>();
            return services;
        }
    }
}
