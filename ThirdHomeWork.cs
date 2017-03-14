using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ThirdHomeWork
{
    [TestFixture]
    public class ThirdHomework
    {
        private Dictionary<IWebElement, string> usedIWebElements = new Dictionary<IWebElement,string>();
        ClickElement confirmLogin = new ClickElement();
        SendDataToWebElement sendLoginData = new SendDataToWebElement();
        Dictionary<int, List<string>> subcategories = new Dictionary<int, List<string>>();
        ClickSubcategories clickSubcategories;
        int numberOfImagesOnSite;

        [SetUp]
        public void start()
        {
            //Log into Admin Panel
            usedIWebElements.Add(new GetWebElement().GetElement(WebElementToFind.username), ApplicationData.username);
            usedIWebElements.Add(new GetWebElement().GetElement(WebElementToFind.password), ApplicationData.password);
            sendLoginData.SendData(usedIWebElements);
            confirmLogin.click(new GetWebElement().GetElement(WebElementToFind.login));
        }

        [Test]
        public void SecoundTest()
        {
            //Click all categories and subCategories on left panel and count images
            ClickCategories ClickElementsOnLeftPanel = new ClickCategories(ApplicationData.leftBoxLocation);
            subcategories = new SubcategoriesOnWebsite().CollectSubcategoriesOnWebsite();
            numberOfImagesOnSite += new GetWebElement().GetImagesNumberOnWebsite(ApplicationData.imagesOnLeftPanel);
            
            int numberOfElementsOnSideBar = new GetWebElement().GetElementsOnLeftSidebar(ApplicationData.leftBoxLocation).Count;
            clickSubcategories = new ClickSubcategories(numberOfElementsOnSideBar); 
            for (int i = 1; i < numberOfElementsOnSideBar; i++)
            {
                numberOfImagesOnSite += new GetWebElement().GetImagesNumberOnWebsite(ApplicationData.imagesOnRightPanel);
                ClickElementsOnLeftPanel.ClickMainCategories(numberOfElementToFind: i);
                foreach (var subcategory in subcategories[i - 1])
                {
                    clickSubcategories.ClickSingleCategory(subcategory);
                    numberOfImagesOnSite += new GetWebElement().GetImagesNumberOnWebsite(ApplicationData.imagesOnLowerRightPanel);
                }
            }
            Console.WriteLine("Number of images on site: {0}", numberOfImagesOnSite);
        }

        [TearDown]
        public void stop()
        {
            WebDriver.ManageWebDriverInstance.Close();
            WebDriver.ManageWebDriverInstance = null;
        }
    }
}
