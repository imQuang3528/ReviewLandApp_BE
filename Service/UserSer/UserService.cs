using Entities.JWT;
using IRepository.IUserRepository;
using IService.IUserSer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Service.UserSer
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUtils _utils;
        public UserService(IUserRepository userRepository, IUtils utils)
        {
            _userRepository = userRepository;
            _utils = utils;
        }

        public async Task<AuthenticationResponse> GetDetailUser(AuthenticationRequest user)
        {
            var result = await _userRepository.GetDetailUser(user);
            if (result == null) return null;
            var jwtToken = _utils.GenerateToken(result);
            var refreshToken = _utils.GenerateRefreshToken();
            refreshToken.UserId = result.IdUser;
            _ = _userRepository.UpdateRefreshToken(refreshToken);
            _utils.SetTokenToCookies(refreshToken.Token);
            return new AuthenticationResponse(result, jwtToken, refreshToken.Token);
        }

        public async Task<AuthenticationResponse> GetUserByToken(string token)
        {
            var lstResult = await _userRepository.GetUserByToken(token);
            if (lstResult?.Count() > 0)
            {
                var user = new UserInfor();
                user = (UserInfor)lstResult[0][0];
                user.RefreshTokens = lstResult[1].Cast<RefreshToken>().ToList();

                var refreshToken = user.RefreshTokens.Find(x => x.Token == token);
                if (!refreshToken.IsActive) return null;

                var newRefreshToken = _utils.GenerateRefreshToken();
                newRefreshToken.Revoked = DateTime.Now;
                newRefreshToken.ReplaceByToken = token;
                newRefreshToken.UserId = user.IdUser;
                _ = _userRepository.UpdateRefreshToken(newRefreshToken);

                var jwtToken = _utils.GenerateToken(user);
                _utils.SetTokenToCookies(newRefreshToken.Token);
                return new AuthenticationResponse(user, jwtToken, newRefreshToken.Token);
            }

            return null;
        }

        public async Task<bool> RevokeToken(string token)
        {
            var lstUser = await _userRepository.GetUserByToken(token);
            if (lstUser?.Count() > 0)
            {
                var userInfo = new UserInfor();
                userInfo = (UserInfor)lstUser[0][0];
                userInfo.RefreshTokens = lstUser[1].Cast<RefreshToken>().ToList();

                var refreshToken = userInfo.RefreshTokens.Find(x => x.Token == token);
                if (!refreshToken.IsActive) return false;
                refreshToken.Revoked = DateTime.UtcNow;
                refreshToken.UserId = userInfo.IdUser;
                _ = _userRepository.UpdateRefreshToken(refreshToken);
                return true;
            }
            return false;
        }
    }
}
