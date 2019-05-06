using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    public class TutByMainPage
    {
        private IWebDriver _driver;

        private WebDriverWait _wait;

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//span[@title = 'ivan.chepik@bk.ru']")]
        private IWebElement EmailSenderElement { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//span[@title='ivan.chepik@bk.ru']/following::span[1]/child::span[1]")]
        private IWebElement SignOfUnread { get; set; }        

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//div[@class = 'mail-Message-Body-Content']/div/div[1]")]
        private IWebElement TextReceivedLetter { get; set; }

        public TutByMainPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(this._driver, this);
        }

        public bool CheckLetter(string textLetter)
        {

            if (!SignOfUnread.GetAttribute("class").Contains("state_toRead"))
            {
                throw new WrongMessageException();
            }

            EmailSenderElement.Click();

            if (!TextReceivedLetter.Text.Equals(textLetter))
            {
                throw new WrongMessageException();
            }

            return true;
        }
    }
}