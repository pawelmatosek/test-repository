using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SecoundHomeWork
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
