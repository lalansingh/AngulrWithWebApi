using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccess.Contract
{
    public interface IUserManager
    {
        UserModel ValidateUser(string userId, string password);
        UserModel UserDetails(string userId);
    }
}
