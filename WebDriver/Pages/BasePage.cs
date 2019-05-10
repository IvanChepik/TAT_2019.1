using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;

        protected WebDriverWait Wait;

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(this.Driver, this);
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(40));
        }

        protected void WaitForElementDisplayed(IWebElement element, IWebDriver driver)
        {
            this.Wait.Until(x => element.Displayed ? element : null);
        }

        protected void WaitForElementIsNotDisplayed(IWebElement element, IWebDriver driver)
        {
            this.Wait.Until(x => !element.Displayed ? element : null);
        }
    }
}