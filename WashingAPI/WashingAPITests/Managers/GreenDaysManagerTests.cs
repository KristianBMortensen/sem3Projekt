using Microsoft.VisualStudio.TestTools.UnitTesting;
using WashingAPI.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WashingAPI.Managers.Tests
{
    [TestClass()]
    public class GreenDaysManagerTests
    {
        private GreenDaysManager _manager;

        [TestInitialize()]
        public void Init()
        {
            _manager = new();
        }

        [TestMethod()]
        public void GetActionTest()
        {
            GreenDaysManager.lastAction = DateTime.Parse("1 Jan 1970 00:00:00");
            GreenDaysManager.startTime = DateTime.Parse("1 Jan 1970 00:00:00");
            GreenDaysManager.start = false;
            GreenDaysManager.actuallyRuns = false;
            Assert.AreEqual(new KeyValuePair<bool, string>(false, "00:00:00"), _manager.GetAction());

            GreenDaysManager.lastAction = DateTime.Parse("1 Jan 1970 00:00:00");
            GreenDaysManager.startTime = DateTime.Parse("1 Jan 1970 00:00:00");
            GreenDaysManager.start = true;
            GreenDaysManager.actuallyRuns = false;
            Assert.AreEqual(new KeyValuePair<bool, string>(false, "00:00:00"), _manager.GetAction());

            GreenDaysManager.lastAction = DateTime.Parse("19 May 2022 13:08");
            GreenDaysManager.startTime = DateTime.Parse("19 May 2022 13:00");
            GreenDaysManager.start = true;
            GreenDaysManager.actuallyRuns = true;
            DateTime future = GreenDaysManager.startTime;
            future = future.AddMinutes(90);
            TimeSpan timeLeft = future - DateTime.UtcNow;
            Assert.AreEqual(new KeyValuePair<bool, string>(true, timeLeft.Hours + ":" + timeLeft.Minutes + ":" + timeLeft.Seconds), _manager.GetAction());
        }

        [TestMethod()]
        public void UpdateLastActionTest()
        {
            _manager.UpdateLastAction();
            Assert.IsTrue(_manager.GetAction().Key);
        }
    }
}