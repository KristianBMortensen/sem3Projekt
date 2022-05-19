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
    public class DaysManagerTests
    {
        DaysManager _daysManager;

        [TestInitialize]
        public void init()
        {
            _daysManager = new();
        }

        [TestMethod()]
        public void GetAllDaysTest()
        {
            List<Day> days = _daysManager.GetAllDays("");
            Assert.AreEqual("19-05-2022", days[0].ResDate);
        }

        [TestMethod()]
        public void GetDayTest()
        {
            var day = _daysManager.GetDay("19-05-2022");
            Assert.AreEqual("19-05-2022", day.ResDate);
        }

        [TestMethod()]
        public void BookTimeTest()
        {
            _daysManager.BookTime(560, "102474468596296399731");
            var day = _daysManager.GetDay("19-05-2022");
            Assert.AreEqual("28A", day.Timeslots.Where(d => d.Id == 560).FirstOrDefault().RoomNo);
            _daysManager.DeleteBooking(560);
            Assert.AreEqual(null, _daysManager.GetDay("19-05-2022").Timeslots.Where(d => d.Id == 560).FirstOrDefault().RoomNo);
        }
    }
}