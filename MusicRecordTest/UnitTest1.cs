using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace MusicRecordTest
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\seleniumDrivers2";
        private static IWebDriver _driver;

        // https://www.automatetheplanet.com/mstest-cheat-sheet/

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory); // fast
            // if your Chrome browser was updated, you must update the driver as well ...
            //    https://chromedriver.chromium.org/downloads
            //_driver = new FirefoxDriver(DriverDirectory);  // slow
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            _driver.Navigate().GoToUrl("http://localhost:61187/");
            string title = _driver.Title;
            Assert.AreEqual("Music Records", title);

            IWebElement buttonElement = _driver.FindElement(By.Id("getAllButton"));
            buttonElement.Click();

            //IWebElement carList = _driver.FindElement(By.Id("carlist")); // No such element

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // decorator pattern?
            IWebElement recordList = wait.Until(d => d.FindElement(By.Nr("recordlist")));
            Assert.IsTrue(recordList.Text.Contains("Volvo"));
        }
    }
}