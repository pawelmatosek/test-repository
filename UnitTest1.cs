using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace FirstHomeWork
{
    [TestFixture]
    public class MyFirstTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            //Initialize Chrome driver
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        [Test]
        public void FirstTest()
        {
            // Open Google Maps WebSite
            driver.Url = "https://maps.google.com/";
        }

        [TearDown]
        public void stop()
        {
            // Close WebSite and end the Webdriver session
            driver.Quit();
            driver = null;
        }
    }
}