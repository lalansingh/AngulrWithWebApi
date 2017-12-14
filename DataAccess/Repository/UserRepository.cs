using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CommonData;
using DataAccess.Repository.Contract;
using DataAccess.RepositoryModel;
using DataModel;

namespace DataAccess.Repository
{
    [DependencyRegister]
    public class UserRepository : IUserRepository
    {
        private readonly AsyncLazy<PortalContext> _portalContext;

        public UserRepository(IPortalContextFactory portalContextFactory)
        {
            _portalContext = portalContextFactory.CreateAsyncLazy();
        }


        public UserModel ValidateUser(string userId, string password)
        {
            var context = Task.FromResult(_portalContext.Value).Unwrap().Result;
            var user = context.Users.Where(x => x.LoginName == userId && x.Password == password).Select(
                u => new UserModel()
                {
                    UserId = u.UserId,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName

                }).FirstOrDefault();
            return user;
        }

        public UserModel UserDetails(string userId)
        {
            var context = Task.FromResult(_portalContext.Value).Unwrap().Result;
            var user = context.Users.Where(x => x.LoginName == userId).Select(
                u => new UserModel()
                {
                    UserId = u.UserId,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName

                }).FirstOrDefault();
            return user;
        }

        public async Task<bool> CreateRefreshTokenAsync(RefreshTokenModel refreshToken)
        {
            var refreshTokenEntityModel = new RefreshToken()
            {
                RefreshTokenId = refreshToken.RefreshTokenId,
                ClientId = refreshToken.ClientId,
                UserId = refreshToken.UserId,
                IssuedUtc = refreshToken.IssuedUtc,
                ExpiresUtc = refreshToken.ExpiresUtc,
                ProtectedTicket = refreshToken.ProtectedTicket
            };
            var context = Task.FromResult(_portalContext.Value).Unwrap().Result;
            context.RefreshToken.Add(refreshTokenEntityModel);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckIftheIncomingTokenIsPresent(Guid refreshToken)
        {
            var context = Task.FromResult(_portalContext.Value).Unwrap().Result;
            return await context.RefreshToken.AnyAsync(x => x.RefreshTokenId == refreshToken);
        }

        public async Task<RefreshTokenModel> DeleteRefreshTokenAsync(Guid refreshTokenId)
        {
            var context = Task.FromResult(_portalContext.Value).Unwrap().Result;
            var token = context.RefreshToken.FirstOrDefault(m => m.RefreshTokenId == refreshTokenId);
            if (token?.ProtectedTicket == null) return new RefreshTokenModel();
            context.RefreshToken.Remove(token);
            await context.SaveChangesAsync();
            return new RefreshTokenModel()
            {
                ClientId = token.ClientId,
                UserId = token.UserId,
                IssuedUtc = token.IssuedUtc,
                ExpiresUtc = token.ExpiresUtc,
                ProtectedTicket = token.ProtectedTicket,
                RefreshTokenId = token.RefreshTokenId
            };
        }
    }
}

