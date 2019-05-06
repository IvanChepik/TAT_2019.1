using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using Logic;

namespace WebTest
{
    [TestFixture]
    public class TutLoginTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //_driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            _driver.Navigate().GoToUrl("https://mail.tut.by");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        [TestCase("IvanChepik153821", "Mc0591434")]
        public void LoginPositiveTest(string login, string password)
        {
            var loginLogic = new LoginLogic(_driver);
            var result = loginLogic.Login(login, password, Emails.TutBy);
            Assert.True(result);
        }

        [Test]
        [TestCase("KERIvanChepik153821", "Mc0591434")]
        [TestCase("IvanChepik153821", "12345678")]
        [TestCase("gdafasf", "zgdsasf")]
        [TestCase("", "")]
        public void LoginNegativeTest(string login, string password)
        {
            var loginLogic = new LoginLogic(_driver);
            Assert.Throws<NotLoginException>
            (
                () => loginLogic.Login(login, password, Emails.TutBy)
            );
        }
    }
}