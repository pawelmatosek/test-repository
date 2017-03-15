using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FourthHomeWork
{
    class ClickCategories
    {
        ClickElement clickElement = new ClickElement();
        SubcategoriesOnWebsite subCategoires = new SubcategoriesOnWebsite();
        string _categoryLocation;
        List<IWebElement> mainWebCategoriesList;

        public ClickCategories(string categoryLocation)
        {
            _categoryLocation = categoryLocation;
            mainWebCategoriesList = new List<IWebElement>();
        }

        private void PerformPreWork()
        {
            var elementsOnSideBar = new GetWebElement().GetElements(_categoryLocation);
            mainWebCategoriesList = new List<IWebElement>(elementsOnSideBar);
        }

        public void ClickElementOnRightPanel(IWebElement elementToClick)
        {
            clickElement.click(elementToClick);
            WebDriver.Refresh();
        }

        public void ClickMainCategories(int numberOfElementToFind)
        {
            PerformPreWork();
            IWebElement mainWebCategoryToClick = mainWebCategoriesList.Find(x => x.Text.Contains(MainCategoriesOnWebSite.CategoriesText[numberOfElementToFind]));
           
            clickElement.click(mainWebCategoryToClick);
            WebDriver.Refresh();
        }

        public void ClickSubCategory(List<string> subCategories)
        {
            var driver = WebDriver.ManageWebDriverInstance;
            PerformPreWork();
            foreach (var subCategory in subCategories)
            {             
                var elementToClick = driver.FindElement(By.Id("doc-" + subCategory));
                clickElement.TryToClickElement(elementToClick);
            }
            WebDriver.Refresh();
        }
    }
}
