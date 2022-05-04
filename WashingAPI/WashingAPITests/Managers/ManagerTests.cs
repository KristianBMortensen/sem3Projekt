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
    public class ManagerTests
    {
        [TestMethod()]
        public void GetAllDaysTest()
        {
            DaysManager manager = new();
            List<Day> days = manager.GetAllDays();
            Assert.AreEqual("04-05-2022", days[0].Date);



        }
    }
}