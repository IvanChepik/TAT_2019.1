using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using Logic;

namespace WebTest
{
    [TestFixture]
    public class MailLoginTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            _driver.Navigate().GoToUrl("https://mail.ru");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        [TestCase("ivan.chepik@bk.ru", "Xe5t2TRj")]
        public void LoginPositiveTest(string login, string password)
        {
            var loginLogic = new LoginLogic(_driver);
            var result = loginLogic.Login(login, password, Emails.MailRu);
            Assert.True(result);
        }

        [Test]
        [TestCase("wete@mail.ru", "asdagdhyuge")]
        [TestCase("", "")]
        [TestCase("ivan.chepik@bk.ru", "asdagdhyuge")]
        [TestCase("wete@mail.ru", "Xe5t2TRj")]
        public void LoginNegativeTest(string login, string password)
        {
            var loginLogic = new LoginLogic(_driver);
            Assert.Throws<NotLoginException>
            (
                () => loginLogic.Login(login, password, Emails.MailRu)
            );
        }
    }
}