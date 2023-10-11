using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ReviewLandApp.Helpers
{
    public class CheckAccessMiddleWare
    {
        private readonly RequestDelegate _next;
        public CheckAccessMiddleWare(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);
        }
    }
}
