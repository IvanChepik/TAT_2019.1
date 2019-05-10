using System;
using OpenQA.Selenium;
using Pages;

namespace Logic
{
    public class ResponseLetterLogic
    {
        private readonly IWebDriver _driver;

        public ResponseLetterLogic(IWebDriver driver)
        {
            this._driver = driver;
        }

        public bool GiveResponseLetter(string textOfLetter)
        {
            try
            {
                var letterPage = new TutByLetterPage(_driver);
                letterPage.SendResponse(textOfLetter);

                this._driver.Navigate().GoToUrl("https://mail.ru");
                var loginLogic = new LoginLogic(this._driver);
                loginLogic.Login("ivan.chepik@bk.ru", "Xe5t2TRj", Emails.MailRu);

                var mailMainPage = new MailRuMainPage(_driver);
                mailMainPage.CheckLetter(textOfLetter);
                mailMainPage.OpenUserInfo();

                var mailRuUserInfo = new MailRuUserInfoPage(_driver);
                mailRuUserInfo.ChangeNickname(textOfLetter);

                mailMainPage.OpenUserInfo();
                var result = mailRuUserInfo.CheckChangingNickName(textOfLetter);

                return result;
            }
            catch
            {
                throw new LetterException();
            }
        }
    }
}