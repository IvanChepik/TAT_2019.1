using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using Logic;

namespace WebTest
{
    [TestFixture]
    public class LoginTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            _driver.Navigate().GoToUrl("https://mail.ru");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        [TestCase("ivan.chepik@bk.ru", "Xe5t2TRj")]
        public void Login_PositiveTest(string login, string password)
        {
            var loginLogic = new LoginLogic(_driver);
            loginLogic.Login(login, password);
            Assert.True(_driver.Url.Contains("/inbox/"));
        }

        [Test]
        [TestCase("wete@mail.ru", "asdagdhyuge")]
        [TestCase("", "")]
        [TestCase("ivan.chepik@bk.ru", "asdagdhyuge")]
        [TestCase("wete@mail.ru", "Xe5t2TRj")]
        public void Login_NegativeTest(string login, string password)
        {
            var loginLogic = new LoginLogic(_driver);
            loginLogic.Login(login, password);
            Assert.False(_driver.Url.Contains("/inbox/"));
        }
    }
}