using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Globalization;

namespace UnitTestProject3
{
    class Calendar
    {
        string format = "ddd dd MMM h:mm tt yyyy";
        DateTime dateTime;

        private void ValidateInput(IWebDriver driver, string cssSelector, string date)
        {
            if (driver == null)
                throw new SystemException("Driver is not set to an instance of an object");
            if (cssSelector.Equals(""))
                throw new SystemException("Passed Css selector is empty");
            if (DateTime.TryParseExact(date, format, CultureInfo.InvariantCulture,
              DateTimeStyles.None, out dateTime))
                Console.WriteLine("Passed Data is in correct format");
        }

        public void SetDatepicker(IWebDriver driver, string XPathSelector, string date)
        {
            ValidateInput(driver, XPathSelector, date);
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until<bool>(
                d => driver.FindElement(By.XPath(XPathSelector)).Displayed);
            driver.FindElement(By.XPath(XPathSelector)).SendKeys(date);
           
            
            
            driver.FindElement(By.CssSelector("body")).Click();
        }
    }
}
