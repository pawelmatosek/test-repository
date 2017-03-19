using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthHomeWork
{
    class YellowDuck
    {
        //Yellow Duck Locators
        public static string YellowDuckProductName = ApplicationData.YellowDuckLockator + "/div[@class='name']";
        public static string YellowDuckBasicPrice = ApplicationData.YellowDuckLockator + "/div[@class='price-wrapper']/s[@class='regular-price']";
        public static string YellowDuckCampainPrice = ApplicationData.YellowDuckLockator + "/div[@class='price-wrapper']/strong[@class='campaign-price']";
        GetWebElement getWebElement = new GetWebElement();
        IWebElement productRegularPrice;
        IWebElement productCampainPrice;

        public void Validate()
        {
            ValidateProductName();
            BasicPrice();
            BasicPriceTextColor();
            BasicPriceTextLineThrough();
            CampainPrice();
            CampainPriceTextBold();
            CampainPriceTextColor();
        }

        private void ValidateProductName()
        {
            IWebElement productName = getWebElement.GetFirstObjectDataByXPath(YellowDuckProductName);
            Console.WriteLine("Check if Product Name is Yellow Duck");
            Assert.AreEqual(productName.Text, "Yellow Duck");
        }

        private void BasicPrice()
        {
            productRegularPrice = getWebElement.GetFirstObjectDataByXPath(YellowDuckBasicPrice);
            Console.WriteLine("Check if Product Regular Price is 20$");
            Assert.AreEqual(productRegularPrice.Text, "$20");
        }

        private void BasicPriceTextColor()
        {
            Console.WriteLine("Check if Product Regular Price color");
            var textColor = productRegularPrice.GetCssValue("color");
            Assert.AreEqual(textColor, "rgba(119, 119, 119, 1)");         
        }

        private void BasicPriceTextLineThrough()
        {
            Console.WriteLine("Check if Product Regular Price is lined-through");
            var textStyle = productRegularPrice.GetCssValue("text-decoration");
            Assert.AreEqual(textStyle, "line-through");
        }

        private void CampainPrice()
        {
            productCampainPrice = getWebElement.GetFirstObjectDataByXPath(YellowDuckCampainPrice);
            Console.WriteLine("Check if Product Campain Price is 18$");
            Assert.AreEqual(productCampainPrice.Text, "$18");
        }

        private void CampainPriceTextBold()
        {
            Console.WriteLine("Check if Product Campain Price is bold");
            var textWeight = productCampainPrice.GetCssValue("font-weight");
            Assert.AreEqual(textWeight, "bold");
        }

        private void CampainPriceTextColor()
        {
            Console.WriteLine("Check if Product Regular Price color");
            var textColor = productCampainPrice.GetCssValue("color");
            Assert.AreEqual(textColor, "rgba(204, 0, 0, 1)");
        }
    }
}
