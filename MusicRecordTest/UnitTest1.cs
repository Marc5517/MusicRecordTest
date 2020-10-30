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
        //private static readonly string DriverDirectory = "C:\\Users\\trist\\Downloads\\chromedriver_win32real";
        private static readonly string DriverDirectory = "C:\\Users\\Marc\\Downloads\\selenium";
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
        public void TestMethod1Task1()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            string title = _driver.Title;
            Assert.AreEqual("Music Records", title);

            IWebElement buttonElement = _driver.FindElement(By.Id("getAllButton"));
            buttonElement.Click();

            //IWebElement carList = _driver.FindElement(By.Id("recordlist")); // No such element

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // decorator pattern?
            IWebElement recordList = wait.Until(d => d.FindElement(By.Id("recordlist")));
            Assert.IsTrue(recordList.Text.Contains("I'm still standing"));
        }

        [TestMethod]
        public void TestMethod2Task1()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");

            IWebElement buttonElement = _driver.FindElement(By.Id("getAllButton"));
            buttonElement.Click();

            //IWebElement carList = _driver.FindElement(By.Id("recordlist")); // No such element

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // decorator pattern?
            IWebElement recordList = wait.Until(d => d.FindElement(By.Id("recordlist")));
            Assert.IsTrue(recordList.Text.Contains("I'm still standing"));
        }

        [TestMethod]
        public void TestMethod1Task2()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");

            //IWebElement searchWriting = _driver.FindElement(By.Id("searchId"));
            //searchWriting.SendKeys("I'm still standing");
            IWebElement buttonElement = _driver.FindElement(By.Id("getByTitle"));
            buttonElement.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement recordList = wait.Until(d => d.FindElement(By.Id("recordlist")));
            Assert.IsTrue(recordList.Text.Contains("I'm still standing"));
        }

        [TestMethod]
        public void TestMethod2Task2()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");

            IWebElement buttonElement = _driver.FindElement(By.Id("getByArtist"));
            buttonElement.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement recordList = wait.Until(d => d.FindElement(By.Id("recordlist")));
            Assert.IsTrue(recordList.Text.Contains("The Fat Rat"));
        }

        [TestMethod]
        public void TestMethod3Task2()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");

            IWebElement buttonElement = _driver.FindElement(By.Id("getByYearOfPublication"));
            buttonElement.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement recordList = wait.Until(d => d.FindElement(By.Id("recordlist")));
            Assert.IsTrue(recordList.Text.Contains("2000"));
        }
    }
}
