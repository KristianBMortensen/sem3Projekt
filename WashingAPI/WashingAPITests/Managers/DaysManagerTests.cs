using Microsoft.VisualStudio.TestTools.UnitTesting;
using WashingAPI.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WashingAPI.Models;

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
            List<Day> days = _daysManager.GetAllDays();
            Assert.AreEqual("04-05-2022", days[0].Date);
        }

        [TestMethod()]
        public void GetDayTest()
        {
            var day = _daysManager.GetDay("04-05-2022");
            Assert.AreEqual("04-05-2022", day.Date);
        }

        [TestMethod()]
        public void DeleteDayTest()
        {
            _daysManager.DeleteDay("04-05-2022");
            var days = _daysManager.GetAllDays();
            Assert.IsFalse(days.Any((d) => d.Date == "04-05-2022"));
        }

        [TestMethod()]
        public void AddDayTest()
        {
            _daysManager.AddDay("20-12-1999");
            var days = _daysManager.GetAllDays();
            Assert.IsTrue(days.Any((d) => d.Date == "20-12-1999"));
        }

        [TestMethod()]
        public void BookTimeTest()
        {
            _daysManager.BookTime("04-05-2022", "7:30-9:00", "14");
            var day = _daysManager.GetDay("04-05-2022");
            Assert.AreEqual("14", day.Timeslots["7:30-9:00"]);
        }

        [TestMethod()]
        public void RemoveBookingTest()
        {
            Assert.Fail();
        }
    }
}