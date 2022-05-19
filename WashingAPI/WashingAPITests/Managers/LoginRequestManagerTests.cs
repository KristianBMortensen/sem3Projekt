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
    public class LoginRequestManagerTests
    {
        private LoginRequestManager _manager;
        private LoginManager _loginManager;

        [TestInitialize()]
        public void Init()
        {
            _manager = new();
            _loginManager = new();
        }

        [TestMethod()]
        public void GetAllRequestsTest()
        {
            Assert.IsNotNull(_manager.GetAllRequests());
        }

        [TestMethod()]
        public void GetRequestTest()
        {
            string id = "34834956549t033243";
            LoginRequest request = _manager.GetRequest(id);
            Assert.IsNotNull(request);
            Assert.AreEqual(id, request.GoogleId);
        }

        [TestMethod()]
        public void CreateSignupRequestTest()
        {
            LoginRequest request = new LoginRequest()
            {
                GoogleId = "45834095830342",
                Fornavn = "Clause",
                Efternavn = "Yngridsen",
                Room = "42Å"
            };

            Assert.IsTrue(_manager.CreateSignupRequest(request));
            Assert.AreEqual(request, _manager.GetRequest(request.GoogleId));
            Assert.IsTrue(_manager.DeleteRequest(request.GoogleId));
        }

        [TestMethod()]
        public void CreateLoginTest()
        {
            LoginRequest request = new LoginRequest()
            {
                GoogleId = "45834095830342",
                Fornavn = "Clause",
                Efternavn = "Yngridsen",
                Room = "42Å"
            };

            Assert.IsTrue(_manager.CreateSignupRequest(request));
            Assert.AreEqual(request, _manager.GetRequest(request.GoogleId));

            Assert.IsTrue(_manager.CreateLogin(request.GoogleId));
            Login login = _loginManager.GetLogin(request.GoogleId);
            Assert.AreEqual(login, _loginManager.GetLogin(login.GoogleId));
            Assert.IsTrue(_loginManager.DeleteLogin(login.GoogleId));
        }
    }
}