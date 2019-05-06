using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using Logic;

namespace WebTest
{
    [TestFixture]
    public class MailSendLetterTest
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

            var loginLogic = new LoginLogic(_driver);
            loginLogic.Login("ivan.chepik@bk.ru", "Xe5t2TRj", Emails.MailRu);
        }

        //[TearDown]
        //public void TearDown()
        //{
        //    _driver.Quit();
        //}

        [Test]
        [TestCase("IvanChepik153821@tut.by", "Andrey Berenok")]
        public void SendLetterPositiveTest(string email, string textOfLetter)
        {
            var sendLetterLogic = new SendLetterLogic(_driver);
            var result = sendLetterLogic.SendLetter(email, textOfLetter);
            Assert.True(result);
        }

        [Test]
        [TestCase("barbudas.barbudass@gmail.com", "Andrey Berenok")]
        [TestCase("", "Andrey Berenok")]
        [TestCase("sggafagh", "Andrey Berenok")]
        public void SendLetterNegativeTest(string email, string textOfLetter)
        {
            var sendLetterLogic = new SendLetterLogic(_driver);
            Assert.Throws<LetterException>
            (
                () => sendLetterLogic.SendLetter(email, textOfLetter)
            );
        }
    }
}