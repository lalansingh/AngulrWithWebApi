using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Api.Controllers;
using Api.Models;
using AutoMapper;
using BussinessAccess.Contract;
using DataModel;
using Xunit;

namespace UnitTestCase.TestController
{
    public class UserController
    {
        [Fact]
        public void Test_UserDetails()
        {
            var mockUserManager = new Mock<IUserManager>();
            var mockMapper = new Mock<IMapper>();
            mockUserManager.Setup(c => c.UserDetails(It.IsAny<string>())).Returns(new UserModel());

            var objController = new LoginController(mockUserManager.Object, mockMapper.Object);
            var result = objController.UserDetails("4jkd4kj4kk4");

            Assert.Null(result);
        }
    }
}
