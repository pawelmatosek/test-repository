using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ThirdHomeWork
{
    [TestFixture]
    public class ThirdHomework
    {
        private Dictionary<IWebElement, string> usedIWebElements = new Dictionary<IWebElement,string>();
        ClickElement confirmLogin = new ClickElement();
        SendDataToWebElement sendLoginData = new SendDataToWebElement();
        ClickSubcategories clickSubcategories;
        

        [SetUp]
        public void start()
        {
            //Log into Admin Panel
            usedIWebElements.Add(new GetWebElement().GetElement(WebElementToFind.username), ApplicationData.username);
            usedIWebElements.Add(new GetWebElement().GetElement(WebElementToFind.password), ApplicationData.password);
            sendLoginData.SendData(usedIWebElements);
            confirmLogin.click(new GetWebElement().GetElement(WebElementToFind.login));
        }

        [Test]
        public void FirstTest()
        {
            //Click all categories and subCategories on left panel
            ClickMainCategories ClickElementsOnLeftPanel = new ClickMainCategories(ApplicationData.leftBoxLocation);
            int numberOfElementsOnSideBar = new GetWebElement().GetElementsOnLeftSidebar(ApplicationData.leftBoxLocation).Count;
            clickSubcategories = new ClickSubcategories(numberOfElementsOnSideBar);

            for (int i = 1; i < numberOfElementsOnSideBar; i++)
            {
                ClickElementsOnLeftPanel.ClickCategories(numberOfElementToFind: i);
                clickSubcategories.Click();
            }    
        }

        [TearDown]
        public void stop()
        {
            WebDriver.ManageWebDriverInstance.Close();
            WebDriver.ManageWebDriverInstance = null;
        }
    }
}
