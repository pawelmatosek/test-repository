using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnitTestProject3;
using OpenQA.Selenium.Interactions;

namespace FifthHomeWork
{
    [TestFixture]
    public class FifthHomework
    {
        private Dictionary<IWebElement, string> usedIWebElements = new Dictionary<IWebElement,string>();
        ClickElement confirmLogin = new ClickElement();
        ClickElement manageNewProduct = new ClickElement();
        ClickElement standartApplication = new ClickElement();

        SendDataToWebElement sendLoginData = new SendDataToWebElement();
        List<string> xPathLocators;
        GetWebElement webDriver;
        WebDriverWait wait;
        int numberOfWebElementsToAdd = 3;

        [SetUp]
        public void start()
        {
            //Log into Admin Panel
            webDriver = new GetWebElement();
            usedIWebElements.Add(webDriver.GetElement(WebElementToFind.username), ApplicationData.username);
            usedIWebElements.Add(webDriver.GetElement(WebElementToFind.password), ApplicationData.password);
            sendLoginData.SendData(usedIWebElements);
            confirmLogin.Click(webDriver.GetElement(WebElementToFind.login));
            wait = new WebDriverWait(WebDriver.ManageWebDriverInstance, TimeSpan.FromSeconds(15));
       }

        [Test]
        public void TwelfthTest() 
        {   
            //GoTo Standard Application version
            standartApplication.Click(webDriver.GetElement(ApplicationData.standardApplicationLocator));

            for (int i = 0; i < numberOfWebElementsToAdd; i++)
            {
                standartApplication.Click(webDriver.GetElement(ApplicationData.ducksProductLocator));
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(ApplicationData.waitingTest)));
                if (webDriver.IsElementPresent(By.CssSelector(ApplicationData.checkLocator)))
                    manageNewProduct.Click(webDriver.GetElementByXPath(ApplicationData.productSizeSelectorLocator, indexToFind: 1));
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(ApplicationData.buttonToAddNewProductLocator)));
                standartApplication.Click(webDriver.GetElement(ApplicationData.buttonToAddNewProductLocator)); 
                standartApplication.Click(webDriver.GetElement(ApplicationData.homeImageLocator));
            }
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(ApplicationData.itemCartLocator)));
            IWebElement fullCart = webDriver.GetElement(ApplicationData.itemCartLocator);
            Console.WriteLine("Cart data: {0}", fullCart.Text);
            standartApplication.Click(webDriver.GetElement(ApplicationData.itemCartLocator));

            for (int i = 0; i < numberOfWebElementsToAdd; i++)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(ApplicationData.removeItemFromCartLocator)));
                standartApplication.Click(webDriver.GetElement(ApplicationData.removeItemFromCartLocator));
            }
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(ApplicationData.itemCartLocator)));
            IWebElement emptyCart = webDriver.GetElement(ApplicationData.itemCartLocator);
            Console.WriteLine("Cart data: {0}", emptyCart.Text);
            standartApplication.Click(webDriver.GetElement(ApplicationData.itemCartLocator));

        }

        [TearDown]
        public void stop()
        {
            WebDriver.ManageWebDriverInstance.Close();
            WebDriver.ManageWebDriverInstance = null;
        }
    }
}
