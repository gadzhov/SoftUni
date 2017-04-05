using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoShare.Service.Mocks;

namespace PhotoShare.Client.Core.Commands.Tests
{
    [TestClass()]
    public class RegisterUserCommandTests
    {
        [TestMethod()]
        public void TestSuccessfullRegister()
        {
            var commandParameters = new string[] {"test", "passw0rd", "passw0rd", "email@.com"};

            var registerUser = new RegisterUserCommand(new UserServiceMock());
            var result = registerUser.Execute(commandParameters);

            Assert.AreEqual($"User {commandParameters[0]} was registered successfully!", result);
        }
        [TestMethod]
        public void TestFailRegister()
        {
            // Passwords do not match
            try
            {
                var commandParameters = new string[] {"test", "p", "a", "email"};
                var registerUser = new RegisterUserCommand(new UserServiceMock());
                registerUser.Execute(commandParameters);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, "Passwords do not match!");
                return;
            }
            Assert.Fail("No exeption was thrown");
        }
    }
}