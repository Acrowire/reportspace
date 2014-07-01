using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportSpace.CustomerDashboard.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ReportSpace.CustomerDashboard.Core.Services.Tests
{
    [TestClass()]
    public class WebSecurityServiceTests
    {
        #region [ Arrange ]
        public IWebSecurityService SecurityService
        {
            get { return new WebSecurityService();  }
        }
        #endregion


        [TestMethod()]
        public void WebSecurityServiceTest()
        {
            // Arrange 
            IWebSecurityService service = this.SecurityService;

            // Act

            // Assert
            Assert.Inconclusive();
        }

        [TestMethod()]
        public void ChangePasswordTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ConfirmAccountTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateAccountTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateUserAndAccountTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GeneratePasswordResetTokenTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCreateDateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetLastPasswordFailureDateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPasswordChangedDateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPasswordFailuresSinceLastSuccessTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetUserIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetUserIdFromPasswordResetTokenTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InitializeDatabaseConnectionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InitializeDatabaseConnectionTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IsAccountLockedOutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IsAccountLockedOutTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IsConfirmedTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IsCurrentUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LoginTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LogoutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RequireAuthenticatedUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RequireRolesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RequireUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RequireUserTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ResetPasswordTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UserExistsTest()
        {
            Assert.Fail();
        }
    }
}
