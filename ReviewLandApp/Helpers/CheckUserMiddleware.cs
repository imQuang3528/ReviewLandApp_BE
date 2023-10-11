using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ReviewLandApp.Helpers
{
    public class CheckUserMiddleware
    {
        private readonly RequestDelegate _next;
        public CheckUserMiddleware( RequestDelegate next)
        {
            _next = next;   
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);
        }
    }
}
