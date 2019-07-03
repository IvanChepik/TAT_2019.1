using NUnit.Framework;
using Logic;

namespace WebTest
{
    /// <summary>
    /// MailLoginTest
    /// tests login on our service
    /// </summary>
    [TestFixture]
    public class MailLoginTest : BaseTest
    {        
        [Test]
        [TestCase("ivan.chepik@bk.ru", "Xe5t2TRj")]
        public void LoginPositiveTest(string login, string password)
        {
            var loginLogic = new LoginLogic(Driver);
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
            var loginLogic = new LoginLogic(Driver);
            Assert.Throws<NotLoginException>
            (
                () => loginLogic.Login(login, password, Emails.MailRu)
            );
        }
    }
}