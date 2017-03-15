using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace FourthHomeWork
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

        public int GetImagesNumberOnWebsite(string locatorFinderCommand)
        {
            var numberOfImagesOnElement = _driver.FindElements(By.CssSelector(locatorFinderCommand)).Count;
            return numberOfImagesOnElement;
        }

        //Method is created to prevent Stale Reference Exception
        public List<IWebElement> GetNewGeoZonesList()
        {
            List<IWebElement> temporaryList = new List<IWebElement>();
            ReadOnlyCollection<IWebElement> listOfGeoZones = new GetWebElement().GetElements(ApplicationData.getListedZones);
            temporaryList.AddRange(listOfGeoZones);
            return temporaryList;
        }

        public ReadOnlyCollection<IWebElement> GetElements(string sideBarName)
        {
            var WebElements = _driver.FindElements(By.CssSelector(sideBarName));
            if (WebElements.Count == 0)
                throw new Exception("Error occours on finding elements on website");
            return WebElements;
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
