using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.JWT
{
    public class AuthenticationRequest
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
