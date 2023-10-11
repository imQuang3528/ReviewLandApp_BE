using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.JWT
{
    public class UserInfor
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string PassWord { get; set; }
        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
