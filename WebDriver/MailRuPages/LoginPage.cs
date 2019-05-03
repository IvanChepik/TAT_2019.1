using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MailRuPages
{
    public class LoginPage 
    {
        private IWebDriver _driver;

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//input[@class = 'o-control']")]
        private IWebElement LoginButton { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//input[@id = 'mailbox:login']")]
        private IWebElement LoginText { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//input[@id = 'mailbox:password']")]
        private IWebElement PasswordText { get; set; }

        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(this._driver, this);
        }

        public void Login(string login, string password)
        {
            LoginText.SendKeys(login);
            PasswordText.SendKeys(password);
            LoginButton.Click();
        }
    }
}