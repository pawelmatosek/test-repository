using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ThirdHomeWork
{
    public class GetWebElement
    {
        IWebDriver _driver;
        public string ElementName { get; private set; }

        public GetWebElement()
        {
            _driver = WebDriver.ManageWebDriverInstance;
        }

        public IWebElement GetElement(WebElementToFind elementName)
        {
            IWebElement webElement = CheckIfElementIsAvailable(elementName);
            return webElement;
        }

        public ReadOnlyCollection<IWebElement> GetElementsOnLeftSidebar(string sideBarName)
        {
            var WebElements = _driver.FindElements(By.CssSelector(sideBarName));
            if (WebElements.Count == 0)
                throw new Exception("Error occours on finding elements on left application sidebar");
            return WebElements;
        }

        public IWebElement GetConcreteElement(string sideBarName, string concreteElementId)
        {
            var WebElementsAddress = sideBarName + concreteElementId;
            var WebElement = _driver.FindElement(By.CssSelector(WebElementsAddress));
            if (object.ReferenceEquals(WebElement, null))
                throw new Exception("Error occours on finding concrete elements on left application sidebar");
            return WebElement;
        }

        public IWebElement CheckIfElementIsAvailable(WebElementToFind elementName)
        {
            try
            {
                IWebElement webElement = _driver.FindElement(By.Name(Enum.GetName(typeof(WebElementToFind), elementName)));
                return webElement;
            }
            catch
            {
                Console.WriteLine("Cannot find element: {0}", elementName);
                WebDriver.ManageWebDriverInstance.Quit();
                WebDriver.ManageWebDriverInstance = null;
                return null;
            }
        }
    }
}
