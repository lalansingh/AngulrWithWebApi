using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessAccess;
using BussinessAccess.Contract;
using DataAccess.Repository.Contract;
using DataModel;
using Moq;
using Xunit;

namespace UnitTestCase.TestBAL
{
    public class ValidateUserTest
    {
        [Fact]
        public void PassingValidateUserTest()
        {
            var mockDal = new Mock<IUserRepository>();
            mockDal.Setup(c => c.ValidateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new UserModel() {Email = "hilalan.kr@gmail.com"});
            var bal = new UserManager(mockDal.Object);
            var result = bal.ValidateUser("lalan", "singh");

            Assert.Equal("hilalan.kr@gmail.com", result.Email);
        }

        [Fact]
        public void FailingValidateUserTest()
        {
            var mockDal = new Mock<IUserRepository>();
            mockDal.Setup(c => c.ValidateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new UserModel() { Email = "hilalan.kr@gmail.com" });
            var bal = new UserManager(mockDal.Object);
            var result = bal.ValidateUser("lalan", "singh");

            Assert.NotEqual("hilala.kr@gmail.com", result.Email);
        }
    }
}
