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
        public void ClickAllElements(ReadOnlyCollection<IWebElement> elementsToClick)
        {
            foreach(var element in elementsToClick)
            {
                Click(element);
                WebDriver.Refresh();
            }
        }

        public void Click(IWebElement elementToClick)
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
