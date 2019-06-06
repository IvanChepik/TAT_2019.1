using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    /// <summary>
    /// Class BasePage
    /// base entity for other pages
    /// </summary>
    public abstract class BasePage
    {
        protected IWebDriver Driver;

        protected WebDriverWait Wait;

        /// <summary>
        /// Constructor BasePage
        /// setup driver
        /// </summary>
        /// <param name="driver"></param>
        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Driver.Navigate().GoToUrl("https://select.by/kurs/");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        protected void WaitForElementDisplayed(IWebElement element)
        {
            Wait.Until(x => element.Displayed ? element : null);
        }
    }
}
