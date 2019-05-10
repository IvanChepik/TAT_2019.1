using NUnit.Framework;
using Logic;

namespace WebTest
{
    /// <summary>
    /// MailSendLetterTest class
    /// test sending letter from our email service.
    /// </summary>
    [TestFixture]
    public class MailSendLetterTest : BaseTest
    {
        [SetUp]
        public new void SetUp()
        {                     
            var loginLogic = new LoginLogic(Driver);
            loginLogic.Login("ivan.chepik@bk.ru", "Xe5t2TRj", Emails.MailRu);
        }

        [Test]
        [TestCase("IvanChepik153821@tut.by", "Andrey Berenok")]
        public void SendLetterPositiveTest(string email, string textOfLetter)
        {
            var sendLetterLogic = new SendLetterLogic(Driver);
            var result = sendLetterLogic.SendLetter(email, textOfLetter);
            Assert.True(result);
        }

        [Test]
        [TestCase("barbudas.barbudass@gmail.com", "Andrey Berenok")]
        [TestCase("", "Andrey Berenok")]
        [TestCase("sggafagh", "Andrey Berenok")]
        public void SendLetterNegativeTest(string email, string textOfLetter)
        {
            var sendLetterLogic = new SendLetterLogic(Driver);
            Assert.Throws<LetterException>
            (
                () => sendLetterLogic.SendLetter(email, textOfLetter)
            );
        }
    }
}