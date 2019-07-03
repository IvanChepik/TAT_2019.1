using NUnit.Framework;
using Logic;

namespace WebTest
{
    /// <summary>
    /// class MailResponseLetterTest
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
            sendLetterLogic.SendLetter("IvanChepik153821@tut.by", "Andrey Berenok")
                            .LoginInEmailReceiver()
                            .CheckLetter("Andrey Berenok");
        }

        [Test]
        [TestCase("1234")]
        public void ResponseLetterPositiveTest(string textOfLetter)
        {                       
            var responseLetterLogic = new ResponseLetterLogic(Driver);
            var result = responseLetterLogic.SendResponseLetter(textOfLetter)
                                            .LoginInAccountReceiver()
                                            .CheckLetter(textOfLetter)
                                            .ChangeNickname(textOfLetter)
                                            .CheckResponseLetter(textOfLetter);          
            Assert.True(result);
        }
    }
}