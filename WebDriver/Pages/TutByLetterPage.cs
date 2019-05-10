using System;
using System.Net.Mime;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    public class TutByLetterPage
    {
        private IWebDriver _driver;

        private WebDriverWait _wait;

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'button-reply ns')]")]
        private IWebElement ReplyButton { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'cke_editable')]")]
        private IWebElement TextLetter { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//span[@class = 'ui-button-text']")]
        private IWebElement SendLetter { get; set; }    
        
        public TutByLetterPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(this._driver, this);
        }

        public bool SendResponse(string textLetter)
        {
            ReplyButton.Click();           
           new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(x => TextLetter.Displayed ? TextLetter : null);
           TextLetter.Clear();
           TextLetter.SendKeys(textLetter);
           SendLetter.Click();
           return true;
        }
    }
}