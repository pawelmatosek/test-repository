using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThirdHomeWork
{
    class ClickMainCategories
    {
        ClickElement clickElement = new ClickElement();
        SubcategoriesOnWebsite subCategoires = new SubcategoriesOnWebsite();
        Dictionary<int, List<string>> sub;
        string _categoryLocation;
        List<IWebElement> mainWebCategoriesList;

        public ClickMainCategories(string categoryLocation)
        {
            _categoryLocation = categoryLocation;
            mainWebCategoriesList = new List<IWebElement>();
        }

        private void PerformPreWork()
        {
            var elementsOnSideBar = new GetWebElement().GetElementsOnLeftSidebar(_categoryLocation);
            mainWebCategoriesList = new List<IWebElement>(elementsOnSideBar);
        }

        //Check headers of elements
        private void CheckHeader(IWebElement WebElementToCheck, int NumeberOfElementToCheck)
        {
            if(WebElementToCheck.Text.Equals(MainCategoriesOnWebSite.CategoriesText[NumeberOfElementToCheck]))
                Console.WriteLine("Element {0} has got correct header", WebElementToCheck.Text);
            else
                throw new Exception("Error occours on comparing element header");
        }

        public void ClickCategories(int numberOfElementToFind)
        {
            PerformPreWork();
            IWebElement mainWebCategoryToClick = mainWebCategoriesList.Find(x => x.Text.Contains(MainCategoriesOnWebSite.CategoriesText[numberOfElementToFind]));
            CheckHeader(mainWebCategoryToClick, numberOfElementToFind);
            clickElement.click(mainWebCategoryToClick);
            WebDriver.Refresh();
        }

        public void ClickSubCategories(List<string> subCategories)
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
