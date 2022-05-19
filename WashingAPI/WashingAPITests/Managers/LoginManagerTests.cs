using Microsoft.VisualStudio.TestTools.UnitTesting;
using WashingAPI.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WashingAPI.DBModels;

namespace WashingAPI.Managers.Tests
{
    [TestClass()]
    public class LoginManagerTests
    {
        private LoginManager _manager;
        [TestInitialize]
        public void Init()
        {
            _manager = new();
        }

        [TestMethod()]
        public void GetAllTokensTest()
        {
            Assert.IsNotNull(_manager.GetAllTokens());
        }

        [TestMethod()]
        public void GetTokenTest()
        {
            string token = "102474468596296399731";
            string getToken = _manager.GetToken(token);
            Assert.AreEqual(token, getToken);
        }

        [TestMethod()]
        public void GetLoginTest()
        {
            Login login = new Login()
            {
                GoogleId = "fisk",
                Fornavn = "Clause",
                Efternavn = "Yngridsen",
                Room = "28A",
                Rolle = "bruger"
            };

            Assert.IsTrue(_manager.CreateToken(login));
            Assert.AreEqual(login, _manager.GetLogin(login.GoogleId));
            Assert.IsTrue(_manager.DeleteLogin(login.GoogleId));
        }
    }
}