using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccess.Repository.Contract
{
    public interface IUserRepository
    {
        UserModel ValidateUser(string userId, string password);
        UserModel UserDetails(string userId);
        Task<bool> CreateRefreshTokenAsync(RefreshTokenModel refreshToken);
        Task<bool> CheckIftheIncomingTokenIsPresent(Guid refreshToken);
        Task<RefreshTokenModel> DeleteRefreshTokenAsync(Guid refreshTokenId);
    }
}
