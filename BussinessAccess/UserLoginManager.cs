using System;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Repository;
using DataAccess.Repository.Contract;
using DataModel;

namespace BussinessAccess
{
    public class UserLoginManager
    {
        readonly IUserRepository _userRepository;

        public UserLoginManager()
        {
            _userRepository = new UserRepository(new PortalContextFactory());
        }

        public UserModel ValidateUser(string userId, string password)
        {
            return _userRepository.ValidateUser(userId, password);
        }

        public async Task<bool> CreateRefreshTokenAsync(RefreshTokenModel refreshToken)
        {
            return await _userRepository.CreateRefreshTokenAsync(refreshToken);
        }

        public async Task<bool> CheckIfheIncomingTokenIsPresent(Guid refreshToken)
        {
            return await _userRepository.CheckIftheIncomingTokenIsPresent(refreshToken);
        }

        public async Task<RefreshTokenModel> DeleteRefreshTokenAsync(Guid refreshTokenId)
        {
            return await _userRepository.DeleteRefreshTokenAsync(refreshTokenId);
        }
    }
}
