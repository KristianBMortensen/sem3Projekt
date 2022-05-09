using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WashingAPI.Models;
using WashingAPI.Managers;

namespace WashingAPITests.Managers
{
    [TestClass]
    class LoginManagerTest
    {
        private LoginManager _manager;

        [TestInitialize]
        public void init()
        {
            _manager = new();
        }

        [TestMethod]
        public void GetAllLoginsTest()
        {
            //List<string> Tokens = _manager.GetTokens();
            //Assert.AreEqual("04-05-2022", Tokens[0]);
        }
    }
}
