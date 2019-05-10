using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
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

        public void ChangeNickname(string newNickname)
        {
            LetterButton.Clear();
            LetterButton.SendKeys(newNickname);
            Wait.Until(x => SubmitButton.Displayed ? SubmitButton : null);
            SubmitButton.Click();
        }

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