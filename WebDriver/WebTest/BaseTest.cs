using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebTest
{
    /// <summary>
    /// class BaseTest
    /// base class for our tests.
    /// </summary>
    public abstract class BaseTest
    {
        protected IWebDriver Driver;

        /// <summary>
        /// Method SetUp
        /// Setup driver for our test
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            Driver = new FirefoxDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            Driver.Navigate().GoToUrl("https://mail.ru");
        }

        /// <summary>
        /// Method TearDown
        /// quit from driver after test
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}