using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.JWT
{
    public class RefreshToken
    {
        public Guid TokenID { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpires => DateTime.Now >= Expires;
        public string ReplaceByToken { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Revoked { get; set; }
        public bool IsActive => Revoked == null && !IsExpires;
        public int UserId { get; set; }
    }
}
