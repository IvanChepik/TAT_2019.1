using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using Logic;

namespace WebTest
{
    [TestFixture]
    public class MailResponseLetterTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Navigate().GoToUrl("https://mail.ru");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        [TestCase("IvanChepik153821@tut.by", "1234")]
        public void ResponseLetterPositiveTest(string email, string textOfLetter)
        {
            var loginLogic = new LoginLogic(_driver);
            loginLogic.Login("ivan.chepik@bk.ru", "Xe5t2TRj", Emails.MailRu);

            var sendLetterLogic = new SendLetterLogic(_driver);
            sendLetterLogic.SendLetter(email, textOfLetter);

            var responseLetterLogic = new ResponseLetterLogic(_driver);
            var result = responseLetterLogic.GiveResponseLetter(textOfLetter);
            Assert.True(result);
        }
    }
}