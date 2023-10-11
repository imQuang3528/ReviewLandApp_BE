using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.JWT
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string JwtToken { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
        public AuthenticationResponse(UserInfor userInfor, string jwtToken, string refreshToken)
        {
            Id = userInfor.IdUser;
            UserName = userInfor.UserName;
            Password = userInfor.PassWord;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }

        public AuthenticationResponse()
        {

        }
    }
}
