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
        ClickElement manageRegistration = new ClickElement();
        SendDataToWebElement sendLoginData = new SendDataToWebElement();
        Dictionary<int, List<string>> subcategories = new Dictionary<int, List<string>>();
        ClickSubcategories clickSubcategories;
        BasicUser basicUser = new BasicUser();
        List<string> locatorsList = new List<string>();
        Actions performRegistrationAction;

        [SetUp]
        public void start()
        {
            //Log into Admin Panel
            usedIWebElements.Add(new GetWebElement().GetElement(WebElementToFind.username), ApplicationData.username);
            usedIWebElements.Add(new GetWebElement().GetElement(WebElementToFind.password), ApplicationData.password);
            sendLoginData.SendData(usedIWebElements);
            confirmLogin.click(new GetWebElement().GetElement(WebElementToFind.login));

            basicUser.CreateUser();
            performRegistrationAction = new Actions(WebDriver.ManageWebDriverInstance);

            locatorsList.Add(ApplicationData.getCaptchaChangeElement);
            locatorsList.Add(ApplicationData.getFalseCaptchaRadioButton);
            locatorsList.Add(ApplicationData.submitRadioButtonChanges);
            locatorsList.Add(ApplicationData.goToStandardApplication);
            locatorsList.Add(ApplicationData.goToNewUserRegistration);
            locatorsList.Add(ApplicationData.goToFirstName);
       }

        [Test]
        public void SecoundTest()
        {
            //Open Security SubCategory in Settings Category  
            ClickCategories ClickElementsOnLeftPanel = new ClickCategories(ApplicationData.leftBoxLocation);
            int numberOfCountriesCategory = MainCategoriesOnWebSite.CategoriesText.IndexOf("Settings");
            ClickElementsOnLeftPanel.ClickMainCategories(numberOfCountriesCategory);
            clickSubcategories = new ClickSubcategories();
            clickSubcategories.ClickSingleCategory("security");

            //Deactivate Captcha and go to new user registration
            foreach (var locator in locatorsList)
                DriverActions.MoveAndClick(locator);

            //Enter user Data
            IWebElement defineUsersCity = new GetWebElement().GetElements(ApplicationData.goToCityInputData)[0];
            performRegistrationAction.MoveToElement(defineUsersCity).ClickAndHold().Release().SendKeys("Gdansk").Perform();

            ReadOnlyCollection<IWebElement> requiredElements = new GetWebElement().GetElements(ApplicationData.collectRequiredElements);
            for (int i = 0; i < requiredElements.Count; i++)
                performRegistrationAction.MoveToElement(requiredElements[i]).ClickAndHold().Release().SendKeys(basicUser.Data[i].GetValue()).Perform();

            manageRegistration.click(new GetWebElement().GetElements(ApplicationData.getUserLoginConfirmationButton)[0]);
            manageRegistration.click(new GetWebElement().GetElements(ApplicationData.logOutFromApplication)[0]);
            
            //Login as new user
            IWebElement logNewUser = new GetWebElement().GetElements(ApplicationData.getLoginHandle)[0];
            performRegistrationAction.MoveToElement(logNewUser).ClickAndHold().Release().SendKeys(basicUser.GetObject("Email").GetValue()).SendKeys(Keys.Tab).Perform();
            performRegistrationAction.SendKeys(basicUser.GetObject("Password").GetValue()).Perform();
            manageRegistration.click(new GetWebElement().GetElements("button[name='login']")[0]);
        }

        [TearDown]
        public void stop()
        {
            WebDriver.ManageWebDriverInstance.Close();
            WebDriver.ManageWebDriverInstance = null;
        }
    }
}
