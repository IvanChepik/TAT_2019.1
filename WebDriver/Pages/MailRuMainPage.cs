using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    public class MailRuMainPage
    {
        private IWebDriver _driver;

        private WebDriverWait _wait;

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//span[@class = 'compose-button__txt']")]
        private IWebElement LetterButton { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//span[@class = 'button2 button2_base button2_primary button2_compact button2_hover-support js-shortcut']")] // тут изменить
        private IWebElement SendLetterButton { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//input[@tabindex = '100']")]
        private IWebElement InputDestination { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//div[@tabindex = '505']")]
        private IWebElement TextLetter { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//a[@id = 'PH_logoutLink']")]
        private IWebElement LogOutButton { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//div[@class = 'llc__item llc__item_correspondent llc__item_unread']")]
        private IWebElement LastLetter { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'style_')]")]
        private IWebElement TextResponseLetter { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//i[@id = 'PH_user-email']")]
        private IWebElement AccountButton { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//span[text() = 'Личные данные']")]
        private IWebElement AccountDataButton { get; set; }

        public MailRuMainPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(this._driver, this);
            this._wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
            this._wait.Until(
                w => !_driver.FindElement(By.XPath("//div[@id = 'app-loader']")).Displayed
                    ? _driver.FindElement(By.XPath("//div[@id = 'app-loader']"))
                    : null);
        }

        public void SendLetter(string email, string textOfLetter)
        {
            this.LetterButton.Click();
            this.InputDestination.SendKeys(email);
            this.TextLetter.SendKeys(textOfLetter);
            this.SendLetterButton.Click();
        }

        public void LogOut()
        {
            LogOutButton.Click();
        }

        public bool CheckLetter(string textLetter)
        {
            LastLetter.Click();
            if (!TextResponseLetter.Text.Equals(textLetter))
            {
                throw new WrongMessageException();
            }
            return true;
        }

        public bool OpenUserInfo()
        {
            AccountButton.Click();
            AccountDataButton.Click();
            return true;
        }
    }
}
