using Entities.AppSetting;
using Entities.JWT;
using IRepository.IUserRepository;
using Microsoft.Extensions.Options;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRepository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private IOptions<AppSetting> _options;
        public UserRepository(IOptions<AppSetting> options) : base(options)
        {
            _options = options;
        }

        public async Task<UserInfor> GetDetailUser(AuthenticationRequest authenticateUser)
        {
            var proc = "GET_USER_DETAIL";
            var response = await QuerySingleUsingStoreProcedure<UserInfor>(proc, authenticateUser);
            return response;
        }

        public async Task<bool> UpdateRefreshToken(RefreshToken refreshToken)
        {
            var proc = "UPDATE_REFRESH_TOKEN";
            var result = await ExecuteUsingStoreProcedure(proc, refreshToken);
            return result;
        }

        public async Task<List<List<object>>> GetUserByToken(string token)
        {
            var proc = "GET_USER_BY_TOKEN";
            var param = new Dictionary<string, object>();
            param.Add("Token", token);
            var lstObj = await QueryMultipleUsingStoreProcedure(new List<Type>() { typeof(UserInfor), typeof(RefreshToken) }, proc, param);
            return lstObj;
        }
    }
}
