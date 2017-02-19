using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecoundHomeWork
{
    class ClickElement
    {
        public ClickElement()
        {
            //_driver = WebDriver.ManageWebDriverInstance;
        }

        public void click(IWebElement elementToClick)
        {
            TryToClickElement(elementToClick);
        }

        public void TryToClickElement(IWebElement elementToClick)
        {
            try
            {
                elementToClick.Click();             
            }
            catch
            {
                Console.WriteLine("Cannot click element");
                WebDriver.ManageWebDriverInstance.Quit();
                WebDriver.ManageWebDriverInstance = null;
            }
        }
    }
}
