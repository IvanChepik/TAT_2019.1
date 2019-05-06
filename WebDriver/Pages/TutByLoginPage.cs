using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class TutByLoginPage : BasePage, ILogining
    {
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//input[@name = 'login']")]
        private IWebElement LoginText { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//input[@name = 'password']")]
        private IWebElement PasswordText { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//input[@type = 'submit']")]
        private IWebElement SubmitPassword { get; set; }

        public TutByLoginPage(IWebDriver driver) : base(driver)
        {

        }

        public bool Login(string login, string password)
        {
            LoginText.SendKeys(login);
            PasswordText.SendKeys(password);
            SubmitPassword.Click();
            if (!Driver.Url.Contains("#inbox"))
            {
                throw new WrongUrlException();
            }

            return true;
        }
    }
}