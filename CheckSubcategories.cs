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
        ClickMainCategories ClickElementsOnLeftPanel = new ClickMainCategories(ApplicationData.leftBoxLocation);
        Dictionary<int, List<string>> subcategories;
        int numberOfElementsOnSideBar;
        int numberOfSubcategory;

        public ClickSubcategories(int elementsOnSideBar)
        {
            numberOfElementsOnSideBar = elementsOnSideBar;
            subcategories = ElementsOnLeftSideBar.CollectSubcategoriesOnWebsite();
        }

        public void Click()
        {
            var checkNumberOfSubelements = new GetWebElement().GetElementsOnLeftSidebar(ApplicationData.leftBoxLocation).Count;
            if (checkNumberOfSubelements > numberOfElementsOnSideBar)
            {
                ClickElementsOnLeftPanel.ClickSubCategories(subcategories[numberOfSubcategory]);
                numberOfSubcategory++;
            }
        }
    }
}
