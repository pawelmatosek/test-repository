using FifthHomeWork;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject3
{
    public static class DriverActions
    {
        public static void MoveAndClick(string locatorToFind)
        {
            Actions performRegistrationAction = new Actions(WebDriver.ManageWebDriverInstance);
            IWebElement standartApplicationHandle = new GetWebElement().GetElements(locatorToFind)[0];
            performRegistrationAction.MoveToElement(standartApplicationHandle).ClickAndHold().Release().Perform();
        }
    }
}
