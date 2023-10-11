using Entities.JWT;
using IService.IUserSer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;   
using System.Net;
using System.Threading.Tasks;

namespace ReviewLandApp.Controllers
{
    [Route("v1/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authentication")]
        [AllowAnonymous]
        public async Task<IActionResult> Authentication([FromBody] AuthenticationRequest user)
        {
            var result = await _userService.GetDetailUser(user);
            if (result == null)
                return BadRequest(new { message = "UserName or Password is incorrect" });
            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpPost("refresh-token")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken()
        {
            if (Request.Cookies.ContainsKey("refreshToken"))
            {
                var refreshToken = Request.Cookies["refreshToken"];
                var reponse = await _userService.GetUserByToken(refreshToken);
                if (reponse == null)
                {
                    return Unauthorized(new { message = "Invalid Token" });
                }
                return Ok(reponse);
            }
            return null;
        }

        [HttpPost("revoked-token")]
        public async Task<IActionResult> RevokedToken([FromBody] RevokedTokenRequest revokenToken)
        {
            var token = revokenToken.Token ?? Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });
            var result = await _userService.RevokeToken(token);
            if (!result) return NotFound(new { message = "Token not found" });
            return Ok(new { message = "Token revoked" });
        }

    }
}
