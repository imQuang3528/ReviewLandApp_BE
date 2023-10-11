using Entities.JWT;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.IUserRepository
{
    public interface IUserRepository
    {
        Task<UserInfor> GetDetailUser(AuthenticationRequest authenticateUser);
        Task<List<List<object>>> GetUserByToken(string token);
        Task<bool> UpdateRefreshToken(RefreshToken refreshToken);
    }
}
