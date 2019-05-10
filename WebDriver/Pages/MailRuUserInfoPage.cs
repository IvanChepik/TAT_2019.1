using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    /// <summary>
    /// class MailRuUserInfoPage
    /// object of user info page of mail.ru
    /// </summary>
    public class MailRuUserInfoPage : BasePage
    {
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//input[@id = 'NickName']")]
        private IWebElement LetterButton { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//span[text() = 'Сохранить']")]
        private IWebElement SubmitButton { get; set; }

        public MailRuUserInfoPage(IWebDriver driver) : base(driver)
        {

        }

        /// <summary>
        /// method ChangeNickname
        /// change nickname on text in letter
        /// </summary>
        /// <param name="newNickname"></param>
        public void ChangeNickname(string newNickname)
        {
            LetterButton.Clear();
            LetterButton.SendKeys(newNickname);
            WaitForElementDisplayed(SubmitButton, Driver);
            SubmitButton.Click();
        }

        /// <summary>
        /// method CheckChangingNickName
        /// check for changing Nickname and thrown exception if not changing.
        /// </summary>
        /// <param name="newNickname"></param>
        /// <returns></returns>
        public bool CheckChangingNickName(string newNickname)
        {
            var oldNickname = LetterButton.GetAttribute("value");

            if (!oldNickname.Equals(newNickname))
            {
                throw new WrongMessageException();               
            }

            return true;
        }
    }
}