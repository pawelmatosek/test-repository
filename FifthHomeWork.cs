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

        SendDataToWebElement sendLoginData = new SendDataToWebElement();
        List<string> xPathLocators;
        Actions manageAddingNewProduct;
        Actions manageChangingTabs;
        GetWebElement webDriver;

        [SetUp]
        public void start()
        {
            //Log into Admin Panel
            webDriver = new GetWebElement();
            usedIWebElements.Add(webDriver.GetElement(WebElementToFind.username), ApplicationData.username);
            usedIWebElements.Add(webDriver.GetElement(WebElementToFind.password), ApplicationData.password);
            sendLoginData.SendData(usedIWebElements);
            confirmLogin.Click(webDriver.GetElement(WebElementToFind.login));

            manageAddingNewProduct = new Actions(WebDriver.ManageWebDriverInstance);
            manageChangingTabs = new Actions(WebDriver.ManageWebDriverInstance);
            xPathLocators = new List<string>();
            xPathLocators.Add(ApplicationData.quantityUnitLocator);
            xPathLocators.Add(ApplicationData.deliveryStatusIdLocator);
            xPathLocators.Add(ApplicationData.deliverySoldOutStatusIdLocator);
       }

        [Test]
        public void TwelfthTest() //gtinDataLocator twelfth
        {   
            //Open Catalog Category and Click add New Product
            ClickCategories ClickElementsOnLeftPanel = new ClickCategories(ApplicationData.leftBoxLocation);
            int numberOfCatalogCategory = MainCategoriesOnWebSite.CategoriesText.IndexOf("Catalog");
            ClickElementsOnLeftPanel.ClickMainCategories(numberOfCatalogCategory);

            manageNewProduct.Click(webDriver.GetElement(ApplicationData.addProductButton));
            manageNewProduct.Click(webDriver.GetElement(ApplicationData.enableProductButton));
           
            manageAddingNewProduct.MoveToElement(webDriver.GetElement(ApplicationData.productName)).Click().SendKeys("VagBlaster")  //ToDo Rewrite each Page To Abstract Factory
                .MoveToElement(webDriver.GetElement(ApplicationData.productCode)).Click().SendKeys("##Vag##")
                .MoveToElement(webDriver.GetElement(ApplicationData.addProductSubcategory)).Click()
                .MoveToElement(webDriver.GetElement(ApplicationData.quantityProductLocator)).Click().SendKeys("1")
                .Perform();

            manageNewProduct.Click(webDriver.GetElementByXPath(ApplicationData.defaultCategoryOptions, indexToFind: 1));    
            foreach (var locator in xPathLocators)
                manageNewProduct.Click(webDriver.GetElementByXPath(locator, indexToFind: 1));
            

            Calendar enterCalendarValues = new Calendar();
            enterCalendarValues.SetDatepicker(WebDriver.ManageWebDriverInstance, ApplicationData.productDatesFromValidationLocator, "02/20/2002");
            enterCalendarValues.SetDatepicker(WebDriver.ManageWebDriverInstance, ApplicationData.productDatesToValidationLocator, "02/20/2017");
            manageChangingTabs.MoveToElement(webDriver.GetElement(ApplicationData.moveToInformationTab)).Click().Perform();

            //Enter Information Page Data
            manageNewProduct.Click(webDriver.GetElementByXPath(ApplicationData.manufacturerInformationLocator, indexToFind: 1));
            manageAddingNewProduct.MoveToElement(webDriver.GetElementByXPath(ApplicationData.supplierInformationLocator)).Click() //ToDo Rewrite to Chain of Responsibility
                .MoveToElement(webDriver.GetElementByXPath(ApplicationData.keywordInformationLocator)).Click().SendKeys("It's The best product on the world wide web")
                .MoveToElement(webDriver.GetElementByXPath(ApplicationData.shortDescriptionInformationLocator)).Click().SendKeys("Absoult honest!")
                .MoveToElement(webDriver.GetElementByXPath(ApplicationData.descriptionInformationLocator)).Click().SendKeys("Buy our newest VagBlaster 3000!")
                .MoveToElement(webDriver.GetElementByXPath(ApplicationData.headTitleInformationLocator)).Click().SendKeys("It's so much better than the VagBlaster 2000!")
                .MoveToElement(webDriver.GetElementByXPath(ApplicationData.metaDescriptionInformationLocator)).Click().SendKeys("Now with DigDeep Feature").Perform();

            //Enter Information to Data Page
            manageChangingTabs.MoveToElement(webDriver.GetElement(ApplicationData.moveToDataTab)).Click().Perform();
            manageAddingNewProduct.MoveToElement(webDriver.GetElementByXPath(ApplicationData.skuDataLocator)).Click().SendKeys("sku")
                .MoveToElement(webDriver.GetElementByXPath(ApplicationData.gtinDataLocator)).Click().SendKeys("gtin")
                .MoveToElement(webDriver.GetElementByXPath(ApplicationData.taricDataLocator)).Click().SendKeys("taric")
                .MoveToElement(webDriver.GetElementByXPath(ApplicationData.weightDataLocator)).Click().SendKeys("weight")
                .MoveToElement(webDriver.GetElementByXPath(ApplicationData.firstDimensionDataLocator)).Click().SendKeys("1")
                .MoveToElement(webDriver.GetElementByXPath(ApplicationData.secoundDimensionDataLocator)).Click().SendKeys("2")
                .MoveToElement(webDriver.GetElementByXPath(ApplicationData.thirdDimensionDataLocator)).Click().SendKeys("3")
                .MoveToElement(webDriver.GetElementByXPath(ApplicationData.attributesDataLocator)).Click().SendKeys("Some Attributes").Perform();

            manageNewProduct.Click(webDriver.GetElement(ApplicationData.buttonToSaveProductLocator));
        }

        [TearDown]
        public void stop()
        {
            WebDriver.ManageWebDriverInstance.Close();
            WebDriver.ManageWebDriverInstance = null;
        }
    }
}
