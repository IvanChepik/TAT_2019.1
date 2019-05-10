using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class MailRuLoginPage : BasePage, ILogining
    {

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//input[@class = 'o-control']")]
        private IWebElement LoginButton { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//input[@id = 'mailbox:login']")]
        private IWebElement LoginText { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//input[@id = 'mailbox:password']")]
        private IWebElement PasswordText { get; set; }

        public MailRuLoginPage(IWebDriver driver) : base(driver)
        {
            
        }

        public bool Login(string login, string password)
        {         
            WaitForElementDisplayed(LoginText, Driver);
            LoginText.Clear();
            LoginText.SendKeys(login);
            PasswordText.SendKeys(password);
            LoginButton.Click();
            if (!Driver.Url.Contains("/inbox/"))
            {
                throw new WrongUrlException();
            }

            return true;
        }
    }
}