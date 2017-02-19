using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.Generic;

namespace SecoundHomeWork
{
    [TestFixture]
    public class MyFirstTest
    {
        private Dictionary<IWebElement, string> usedIWebElements = new Dictionary<IWebElement,string>();
        ClickElement confirmLogin = new ClickElement();
        SendDataToWebElement sendLoginData = new SendDataToWebElement();

        [SetUp]
        public void start()
        {
            usedIWebElements.Add(new GetWebElement().GetElement(WebElementToFind.email), ApplicationData.login);
            usedIWebElements.Add(new GetWebElement().GetElement(WebElementToFind.password), ApplicationData.password);
        }

        [Test]
        public void FirstTest()
        { 
            sendLoginData.SendData(usedIWebElements);
            confirmLogin.click(new GetWebElement().GetElement(WebElementToFind.login));           
        }

        [TearDown]
        public void stop()
        {
            WebDriver.ManageWebDriverInstance.Close();
            WebDriver.ManageWebDriverInstance = null;
        }
    }
}
