using System;
using System.Web.Http;
using Api.Filters;
using Api.Models;
using AutoMapper;
using BussinessAccess.Contract;
using CommonData;
using DataModel;

namespace Api.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public LoginController(IUserManager userManager, IMapper mapper)
        {
            if (userManager == null) throw new ArgumentNullException(nameof(userManager));
            _userManager = userManager;
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            _mapper = mapper;
        }

        //public LoginController()
        //{
        //}



        [HttpGet]
        [Route("UserDetails")]
        [ModelValidator]
        [RoleAuthorize(Roles = Roles.Admin)]
        public UserViewModel UserDetails(string userId)
        {
            var result = _userManager.UserDetails(userId);
            var res = _mapper.Map<UserModel, UserViewModel>(result);
            //var rest = Mapper.Map<UserModel, UserViewModel>(result);
            return res;
        }
        
    }
}
