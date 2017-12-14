using System;
using DataModel;
using BussinessAccess.Contract;
using CommonData;
using DataAccess;
using DataAccess.Repository;
using DataAccess.Repository.Contract;

namespace BussinessAccess
{
    [DependencyRegister]
    public class UserManager : IUserManager
    {
        readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            if (userRepository == null) throw new ArgumentNullException(nameof(userRepository));
            _userRepository = userRepository;
        }

        public UserModel ValidateUser(string userId, string password)
        {
            return _userRepository.ValidateUser(userId, password);
        }

        public UserModel UserDetails(string userId)
        {
            return _userRepository.UserDetails(userId);
        }
    }
}
