﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SecoundHomeWork
{
    public static class WebDriver
    {
        static IWebDriver _webDriverInstance;
        static WebDriverWait _wait;
        public static IWebDriver ManageWebDriverInstance
        {
            get
            {
                if (_webDriverInstance == null)
                {
                    _webDriverInstance = new ChromeDriver();
                    _webDriverInstance.Url = ApplicationData.applicationAddress;
                    _wait = new WebDriverWait(_webDriverInstance, TimeSpan.FromSeconds(60));
                }
                return _webDriverInstance;
            }
            set { }
        }
    }
}