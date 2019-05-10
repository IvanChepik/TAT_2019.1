using Pages;
using OpenQA.Selenium;

namespace Logic
{
    public class LoginLogic
    {
        private readonly IWebDriver _driver;

        private ILogining _loginPage;

        public LoginLogic(IWebDriver driver)
        {
            this._driver = driver;
        }

        public bool Login(string email, string password, Emails typeOfEmail)
        {
            try
            {
                switch (typeOfEmail)
                {
                    case Emails.MailRu:
                        _loginPage = new MailRuLoginPage(this._driver);
                        break;
                    case Emails.TutBy:
                        _loginPage = new TutByLoginPage(this._driver);
                        break;
                }

                return _loginPage.Login(email, password);
            }
            catch
            {
                throw new NotLoginException();
            }
        }
    }
}