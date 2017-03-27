using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace FifthHomeWork
{
    public class SendDataToWebElement
    {
        IWebDriver _driver;
        IWebElement _webElement;
        string _dataToSend;

        public SendDataToWebElement()
        {
            _driver = WebDriver.ManageWebDriverInstance;    
        }

        public void SendData(Dictionary<IWebElement, string> usedIWebElements)
        {
            foreach (var element in usedIWebElements)
            {
                _webElement = element.Key;
                TryToSendData(element.Value);
            }
        }

        public void TryToSendData(string dataToSend)
        {
            try
            {
                _webElement.SendKeys(dataToSend);
            }
            catch
            {
                Console.WriteLine("Cannot send data {0} to element", dataToSend);
                WebDriver.ManageWebDriverInstance.Quit();
                WebDriver.ManageWebDriverInstance = null;
            }
        }
    }
}
