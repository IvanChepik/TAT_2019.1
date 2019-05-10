using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    /// <summary>
    /// class MailRuMainPage
    /// object of min page of mail.ru
    /// </summary>
    public class MailRuMainPage : BasePage
    {
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

        /// <summary>
        /// constructor MailRuMainPage
        /// Wait for screen with octopus is not display
        /// </summary>
        /// <param name="driver"></param>
        public MailRuMainPage(IWebDriver driver) : base(driver)
        {
            WaitForElementIsNotDisplayed(Driver.FindElement(By.XPath("//div[@id = 'app-loader']")), Driver);
        }

        /// <summary>
        /// method SendLetter
        /// send letter to email
        /// </summary>
        /// <param name="email">email which receive letter</param>
        /// <param name="textOfLetter">text letter</param>
        public void SendLetter(string email, string textOfLetter)
        {
            this.LetterButton.Click();
            this.InputDestination.SendKeys(email);
            this.TextLetter.SendKeys(textOfLetter);
            this.SendLetterButton.Click();
        }

        /// <summary>
        /// method LogOut
        /// Log out from service
        /// </summary>
        public void LogOut()
        {
            LogOutButton.Click();
        }

        /// <summary>
        /// method CheckLetter
        /// check letter for correctness
        /// </summary>
        /// <param name="textLetter"></param>
        /// <returns></returns>
        public bool CheckLetter(string textLetter)
        {
            LastLetter.Click();
            if (!TextResponseLetter.Text.Equals(textLetter))
            {
                throw new WrongMessageException();
            }
            return true;
        }

        /// <summary>
        /// method OpenUserInfo
        /// open user info page
        /// </summary>
        /// <returns></returns>
        public void OpenUserInfo()
        {
            AccountButton.Click();
            AccountDataButton.Click();
        }
    }
}
