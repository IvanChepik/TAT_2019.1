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


        public MailRuMainPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(this._driver, this);
            this._wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
            this._wait.Until(
                w => !_driver.FindElement(By.XPath("//div[@id = 'app-loader']")).Displayed
                    ? LetterButton
                    : null);
        }

        public void SendLetter(string email, string textOfLetter)
        {
            this.LetterButton.Click();
            this.InputDestination.SendKeys(email);
            this.TextLetter.SendKeys(textOfLetter);
            this.SendLetterButton.Click();
        }
    }
}
