using Entities.JWT;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService.IUserSer
{
    public interface IUserService
    {
        Task<AuthenticationResponse> GetDetailUser(AuthenticationRequest user);

        Task<AuthenticationResponse> GetUserByToken(string token);

        Task<bool> RevokeToken(string token);
    }
}
