using MailRuPages;
using OpenQA.Selenium;

namespace Logic
{
    public class LoginLogic
    {
        private readonly IWebDriver _driver;

        public LoginLogic(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void Login(string login, string password)
        {
            var loginPage = new LoginPage(this._driver);
            loginPage.Login(login, password);
        }
    }
}