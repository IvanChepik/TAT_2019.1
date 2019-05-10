using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using Logic;

namespace WebTest
{
    /// <summary>
    /// MailResponseLetterTest class
    /// tests receive mail by our service.
    /// </summary>
    [TestFixture]
    public class MailResponseLetterTest : BaseTest
    {
        [SetUp]
        public new void SetUp()
        {
            var loginLogic = new LoginLogic(Driver);
            loginLogic.Login("ivan.chepik@bk.ru", "Xe5t2TRj", Emails.MailRu);

            var sendLetterLogic = new SendLetterLogic(Driver);
            sendLetterLogic.SendLetter("IvanChepik153821@tut.by", "Andrey Berenok");
        }

        [Test]
        [TestCase("1234")]
        public void ResponseLetterPositiveTest(string textOfLetter)
        {                       
            var responseLetterLogic = new ResponseLetterLogic(Driver);
            var result = responseLetterLogic.GiveResponseLetter(textOfLetter);
            Assert.True(result);
        }
    }
}