using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace SeliniumTest
{
    [TestClass]
    public class FrontendTest
    {
        IWebDriver driver;
        [TestInitialize]
        public void Init()
        {
            driver = new FirefoxDriver(@"D:\Drivers\FireFoxDriver\");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        [TestMethod]
        public void TestMethod1()
        {
            driver.Url = "http://localhost/";

            driver.FindElement(By.Id("username")).SendKeys("admin");
            driver.FindElement(By.Id("password")).SendKeys("1234");
            driver.FindElement(By.Id("submitLoginForm")).Click();

            Thread.Sleep(1500);

            Assert.IsTrue(driver.FindElement(By.Id("maskineStatus")).Text == "13:30-15:00");

            driver.Close();
        }
    }
}
