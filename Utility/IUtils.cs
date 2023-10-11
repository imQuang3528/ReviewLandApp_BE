using Entities.Contanst;
using Entities.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public interface IUtils
    {
        void SetTokenToCookies(string token);
        string GenerateToken(UserInfor userInfor);
        RefreshToken GenerateRefreshToken();
    }

    public class Utils : IUtils
    {
        private readonly IHttpContextAccessor _httpContext;
        public Utils(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void SetTokenToCookies(string token)
        {
            var cookieOption = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(2)
            };
            _httpContext.HttpContext.Response.Cookies.Append("refreshToken", token, cookieOption);
        }

        public string GenerateToken(UserInfor userInfor)
        {
            var tokenHanler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Constant.SecretKey);
            var credential = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim("member_id",userInfor.IdUser.ToString()),
                new Claim("member_name",userInfor.UserName)
            };

            var token = new JwtSecurityToken(
                Constant.Issuer,
                Constant.Audience,
                claims,
                expires:DateTime.UtcNow.AddMinutes(5),
                signingCredentials: credential
            );

            return tokenHanler.WriteToken(token);
        }

        public RefreshToken GenerateRefreshToken()
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomByte = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomByte);
                return new RefreshToken
                {
                    TokenID = Guid.NewGuid(),
                    Token = Convert.ToBase64String(randomByte),
                    Expires = DateTime.UtcNow.AddDays(2),
                    Created = DateTime.UtcNow
                };
            }
        }
    }
}
