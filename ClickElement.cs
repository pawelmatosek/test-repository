using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifthHomeWork
{
    class ClickElement
    {
        public void clickAllElements(ReadOnlyCollection<IWebElement> elementsToClick)
        {
            foreach(var element in elementsToClick)
            {
                click(element);
                WebDriver.Refresh();
            }
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
