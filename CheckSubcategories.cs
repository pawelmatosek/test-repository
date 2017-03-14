using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdHomeWork
{
    class ClickSubcategories
    {
        SubcategoriesOnWebsite ElementsOnLeftSideBar = new SubcategoriesOnWebsite();
        ClickCategories ClickElementsOnLeftPanel = new ClickCategories(ApplicationData.leftBoxLocation);
        Dictionary<int, List<string>> subcategories;
        int numberOfElementsOnSideBar;
        int numberOfSubcategory;

        public ClickSubcategories(int elementsOnSideBar)
        {
            numberOfElementsOnSideBar = elementsOnSideBar;
            subcategories = ElementsOnLeftSideBar.CollectSubcategoriesOnWebsite();
        }

        public void Click(bool isLastSubcatalog = false)
        {
            var checkNumberOfSubelements = new GetWebElement().GetElementsOnLeftSidebar(ApplicationData.leftBoxLocation).Count;
            if (checkNumberOfSubelements > numberOfElementsOnSideBar)
                ClickElementsOnLeftPanel.ClickSubCategory(subcategories[numberOfSubcategory]);
            if(isLastSubcatalog == true)
                numberOfSubcategory++;
        }

        private Dictionary<int, List<string>> GetSingleSubcategoryDictionary(string subcategory)
        {
            List<string> singleCategoryList = new List<string>();
            singleCategoryList.Add(subcategory);
            Dictionary<int, List<string>>  singleCategoryDictionary = new Dictionary<int, List<string>>();
            singleCategoryDictionary.Add(numberOfSubcategory, singleCategoryList);
            return singleCategoryDictionary;
        }

        public void ClickSingleCategory(string subcategory)
        {
            bool isLastSubcatalog = subcategories[numberOfSubcategory].Last() != subcategory ? false : true;
            subcategories = GetSingleSubcategoryDictionary(subcategory);
            Click(isLastSubcatalog);
            subcategories = ElementsOnLeftSideBar.CollectSubcategoriesOnWebsite();      
        }
    }
}
