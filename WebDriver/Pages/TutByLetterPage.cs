using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class TutByLetterPage : BasePage
    {
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'button-reply ns')]")]
        private IWebElement ReplyButton { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'cke_editable')]")]
        private IWebElement TextLetter { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//span[@class = 'ui-button-text']")]
        private IWebElement SendLetter { get; set; }    
        
        public TutByLetterPage(IWebDriver driver) : base(driver)
        {

        }

        public bool SendResponse(string textLetter)
        {
           ReplyButton.Click();           
           WaitForElementDisplayed(TextLetter, Driver);
           TextLetter.Clear();
           TextLetter.SendKeys(textLetter);
           SendLetter.Click();
           return true;
        }
    }
}