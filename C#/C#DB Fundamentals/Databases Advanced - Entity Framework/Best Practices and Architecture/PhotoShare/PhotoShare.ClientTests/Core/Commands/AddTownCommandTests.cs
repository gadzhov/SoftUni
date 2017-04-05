using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoShare.Service;
using PhotoShare.Service.Mocks;

namespace PhotoShare.Client.Core.Commands.Tests
{
    [TestClass()]
    public class AddTownCommandTests
    {
        [TestMethod()]
        public void AddTownSuccessfullTest()
        {
            var commandParameters = new string[] {"Aitos", "Bulgaria"};

            var addTown = new AddTownCommand(new AddTownServiceMock());
            var result = addTown.Execute(commandParameters);

            Assert.AreEqual(commandParameters[0] + " was added to database!", result);
        }

        [TestMethod()]
        public void AddTownFailTest()
        {
            //"Aitos" should be in the DB to works correctly or run the test twice!
            var commandParameters = new string[] { "Aitos", "Bulgaria" };
            try
            {
                var addTown = new AddTownCommand(new TownService());
                addTown.Execute(commandParameters);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, $"Town {commandParameters[0]} was already added!");
                return;
            }
            Assert.Fail("No exeption thrown");
        }
    }
}