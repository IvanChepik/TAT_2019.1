using OpenQA.Selenium;
using Pages;

namespace Logic
{
    /// <summary>
    /// class SendLetterLogic
    /// send and checks message
    /// </summary>
    public class SendLetterLogic
    {
        private readonly IWebDriver _driver;

        public SendLetterLogic(IWebDriver driver)
        {
            this._driver = driver;
        }

        /// <summary>
        /// method SendLetter
        /// send letter to email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="textOfLetter"></param>
        /// <returns></returns>
        public SendLetterLogic SendLetter(string email, string textOfLetter)
        {
            try
            {
                var mailBoxPage = new MailRuMainPage(_driver);
                mailBoxPage.SendLetter(email, textOfLetter);
                mailBoxPage.LogOut();
                
                return this;
            }
            catch
            {
                throw new LetterException();
            }
        }

        /// <summary>
        /// method CheckLetter
        /// check letter for correctness
        /// </summary>
        /// <param name="textLetter"></param>
        /// <returns></returns>
        public bool CheckLetter(string textLetter)
        {
            try
            {
                var mainPage = new TutByMainPage(_driver);

                return mainPage.CheckLetter(textLetter);
            }
            catch
            {
                throw new LetterException();
            }            
        }

        /// <summary>
        /// method LogInEmailReceiver
        /// log into email receiver
        /// </summary>
        /// <returns></returns>
        public SendLetterLogic LoginInEmailReceiver()
        {
            try
            {
                this._driver.Navigate().GoToUrl("https://mail.tut.by");
                var loginLogic = new LoginLogic(this._driver);
                loginLogic.Login("IvanChepik153821", "Mc0591434", Emails.TutBy);

                return this;
            }
            catch
            {
                throw new LetterException();
            }           
        }
    }
}