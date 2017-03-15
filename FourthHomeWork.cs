using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FourthHomeWork
{
    [TestFixture]
    public class FourthHomework
    {
        private Dictionary<IWebElement, string> usedIWebElements = new Dictionary<IWebElement,string>();
        ClickElement confirmLogin = new ClickElement();
        SendDataToWebElement sendLoginData = new SendDataToWebElement();
        Dictionary<int, List<string>> subcategories = new Dictionary<int, List<string>>();
        ClickSubcategories clickSubcategories;

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
            //Open Countries Main Category:           
            ClickCategories ClickElementsOnLeftPanel = new ClickCategories(ApplicationData.leftBoxLocation);
            int numberOfCountriesCategory = MainCategoriesOnWebSite.CategoriesText.IndexOf("Countries");
            ClickElementsOnLeftPanel.ClickMainCategories(numberOfCountriesCategory);

            //Check if all Countries are in alphabetic order
            ReadOnlyCollection<IWebElement> listOfCountries = new GetWebElement().GetElements(ApplicationData.getListedCountires);
            CheckCountrysOrder checkAlphabeticOrder = new CheckCountrysOrder(listOfCountries);
            Assert.AreEqual(true, checkAlphabeticOrder.Check());
        
            //Open Geo Zones Main Category
            int numberOfGeoZonesCategory = MainCategoriesOnWebSite.CategoriesText.IndexOf("Geo Zones");
            ClickElementsOnLeftPanel.ClickMainCategories(numberOfGeoZonesCategory);

            ReadOnlyCollection<IWebElement> listOfGeoZones = new GetWebElement().GetElements(ApplicationData.getListedZones);
            ClickElementsOnLeftPanel.ClickMainCategories(numberOfGeoZonesCategory);

            for (int i = 0; i < listOfGeoZones.Count; i++)
            {   
                List<IWebElement> geoZonesList = new GetWebElement().GetNewGeoZonesList();
                Console.WriteLine("Check if in {0} Geo Zone Country's are listed in alphanumeric order", geoZonesList[i].Text);
                ClickElementsOnLeftPanel.ClickElementOnRightPanel(geoZonesList[i]);
                CheckCountrysOrder checkGeoZoneAlphabeticOrder = new CheckCountrysOrder(new GetWebElement().GetElements(ApplicationData.getCountyGeoZones));
                Assert.AreEqual(true, checkGeoZoneAlphabeticOrder.Check());
                ClickElementsOnLeftPanel.ClickMainCategories(numberOfGeoZonesCategory);
            }
        }

        [TearDown]
        public void stop()
        {
            WebDriver.ManageWebDriverInstance.Close();
            WebDriver.ManageWebDriverInstance = null;
        }
    }
}
