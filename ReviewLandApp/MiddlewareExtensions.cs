using Microsoft.AspNetCore.Builder;
using ReviewLandApp.Helpers;
using System.Runtime.CompilerServices;

namespace ReviewLandApp
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCheckAccess(this IApplicationBuilder applicationBuilder)
        {
          return applicationBuilder.UseMiddleware<CheckAccessMiddleWare>();
        }

        public static IApplicationBuilder CustomCheckMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckUserMiddleware>();
        }
    }
}
