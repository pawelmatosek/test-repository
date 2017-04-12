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
        ClickSubcategories clickSubcategories;

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

            string mainWindow = WebDriver.ManageWebDriverInstance.CurrentWindowHandle;
            //GoTo Catalog Category
            ClickCategories ClickElementsOnLeftPanel = new ClickCategories(ApplicationData.leftBoxLocation);
            int numberOfCountriesCategory = MainCategoriesOnWebSite.CategoriesText.IndexOf("Catalog");
            ClickElementsOnLeftPanel.ClickMainCategories(numberOfCountriesCategory);
            ClickSubcategories clickSubcategories = new ClickSubcategories();
            clickSubcategories.ClickSingleCategory("catalog");

            manageNewProduct.Click(webDriver.GetElement(ApplicationData.addNewCategoryLocator));

            manageNewProduct.Click(webDriver.GetElement(ApplicationData.addNewCategoryLocator));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(ApplicationData.linkToExternalSite)));
       
            ICollection<string> oldWindows = WebDriver.ManageWebDriverInstance.WindowHandles;

            WebDriver.ManageWebDriverInstance.SwitchTo().Window(oldWindows.GetEnumerator().MoveNext().ToString());

            WebDriver.ManageWebDriverInstance.Close();
            WebDriver.ManageWebDriverInstance.SwitchTo().Window(mainWindow);
        }

        [TearDown]
        public void stop()
        {
            WebDriver.ManageWebDriverInstance.Close();
            WebDriver.ManageWebDriverInstance = null;
        }
    }
}
