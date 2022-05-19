using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace SeliniumTest
{
    [TestClass]
    public class FrontendTest
    {
        private static IWebDriver driver;
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            //driver = new FirefoxDriver(@"D:\Drivers\FireFoxDriver\");
            driver = new ChromeDriver(@"C:\Users\Richard\Documents\SElDrivers");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Url = "http://localhost/";
            driver.FindElement(By.Id("username")).SendKeys("admin");
            driver.FindElement(By.Id("password")).SendKeys("1234");
            driver.FindElement(By.Id("submitLoginForm")).Click();
        }
        [ClassCleanup]
        public static void Cleanup()
        {
            //driver.Dispose();
        }

        [TestMethod]
        public void HomeTest()
        {
            driver.Url = "http://localhost/";
            Thread.Sleep(1500);

            if(driver.FindElement(By.CssSelector("p.vaskemaskine-status")).Text != "LEDIG")
            {
                Assert.IsTrue(driver.FindElement(By.Id("maskineStatus")).Text.Contains("-"));
            }
            else
            {
                Assert.AreEqual("", driver.FindElement(By.Id("maskineStatus")).Text);
            }

            if(DateTime.Now.DayOfWeek == DayOfWeek.Sunday || DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
            {
                Assert.AreEqual("Ingen booking i dag. Tjek status for maksinen", driver.FindElement(By.CssSelector("div.table green-day-box:last-child")));
            }
            else
            {
                Assert.AreEqual("7:30-9:00", driver.FindElement(By.CssSelector("table.kalender-table > thead > tr > th:first-child")).Text);
            }   
        }

        [TestMethod]
        public void OvorsigtTest()
        {
            driver.Url = "http://localhost/oversigt";
            Thread.Sleep(1500);

            DateTime date = DateTime.Now;
            
            for(var i = 1; i < 6; i++)
            {
                if(date.DayOfWeek == DayOfWeek.Wednesday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    Assert.AreEqual(date.ToString("dd:MM:yyyy").Replace(":", "-"), driver.FindElement(By.CssSelector($"div.col-4:nth-child({i}) > div > h3")).Text);
                }
                else
                {
                    Assert.AreEqual(date.ToString("dd:MM:yyyy").Replace(":", "-"), driver.FindElement(By.CssSelector($"div.col-4:nth-child({i}) > table > thead > tr > th")).Text);
                    Assert.AreEqual("7:30-9:00", driver.FindElement(By.CssSelector($"div.col-4:nth-child({i}) > table > tbody > tr > td:first-child")).Text);
                }
                date = date.AddDays(1);
            }
        }


    }
}
