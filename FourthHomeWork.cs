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
        YellowDuck yellowDuck;
        [SetUp]
        public void start()
        {
             yellowDuck = new YellowDuck();
        }

        [Test]
        public void SecoundTest()
        {         
            yellowDuck.Validate();
        }

        [TearDown]
        public void stop()
        {
            WebDriver.ManageWebDriverInstance.Close();
            WebDriver.ManageWebDriverInstance = null;
        }
    }
}
