using Pages;
using OpenQA.Selenium;

namespace Logic
{
    /// <summary>
    /// class LoginLogic
    /// responsible for login 
    /// </summary>
    public class LoginLogic
    {
        private readonly IWebDriver _driver;

        private ILogining _loginPage;

        public LoginLogic(IWebDriver driver)
        {
            this._driver = driver;
        }

        /// <summary>
        /// Method Login
        /// login in mail service by email and password.
        /// Mail service defines by enum
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="typeOfEmail"></param>
        /// <returns></returns>
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