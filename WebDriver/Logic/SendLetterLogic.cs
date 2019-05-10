using OpenQA.Selenium;
using Pages;

namespace Logic
{
    public class SendLetterLogic
    {
        private readonly IWebDriver _driver;

        public SendLetterLogic(IWebDriver driver)
        {
            this._driver = driver;
        }

        public bool SendLetter(string email, string textOfLetter)
        {
            try
            {
                var mailBoxPage = new MailRuMainPage(_driver);
                mailBoxPage.SendLetter(email, textOfLetter);
                mailBoxPage.LogOut();
                this._driver.Navigate().GoToUrl("https://mail.tut.by");
                var loginLogic = new LoginLogic(this._driver);
                loginLogic.Login("IvanChepik153821", "Mc0591434", Emails.TutBy);
                var mainPage = new TutByMainPage(_driver);
                return mainPage.CheckLetter(textOfLetter);
            }
            catch
            {
                throw new LetterException();
            }
        }
    }
}