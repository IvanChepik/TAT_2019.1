using OpenQA.Selenium;
using Pages;

namespace Logic
{
    /// <summary>
    /// ResponseLetterLogic
    /// send response to email and check it
    /// </summary>
    public class ResponseLetterLogic
    {
        private readonly IWebDriver _driver;

        private MailRuUserInfoPage _mailRuUserInfo;

        private MailRuMainPage _mailRuMainPage;

        public ResponseLetterLogic(IWebDriver driver)
        {
            this._driver = driver;
        }

        /// <summary>
        /// Method SendResponseLetter
        /// Send response to email with certain text
        /// </summary>
        /// <param name="textOfLetter"></param>
        /// <returns></returns>
        public ResponseLetterLogic SendResponseLetter(string textOfLetter)
        {
            try
            {
                var letterPage = new TutByLetterPage(_driver);
                letterPage.SendResponse(textOfLetter);

                return this;
            }
            catch
            {
                throw new LetterException();
            }
        }

        /// <summary>
        /// method CheckLetter
        /// check letter for equality text
        /// </summary>
        /// <param name="textOfLetter"></param>
        /// <returns></returns>
        public ResponseLetterLogic CheckLetter(string textOfLetter)
        {
            _mailRuMainPage = new MailRuMainPage(_driver);
            _mailRuMainPage.CheckLetter(textOfLetter);
            _mailRuMainPage.OpenUserInfo();

            return this;
        }
        /// <summary>
        /// method LoginInAccountReceiver
        /// login in account receiver
        /// </summary>
        /// <returns></returns>
        public ResponseLetterLogic LoginInAccountReceiver()
        {
            try
            {
                this._driver.Navigate().GoToUrl("https://mail.ru");
                var loginLogic = new LoginLogic(this._driver);
                loginLogic.Login("ivan.chepik@bk.ru", "Xe5t2TRj", Emails.MailRu);

                return this;
            }
            catch
            {
                throw new LetterException();
            }
        }

        /// <summary>
        /// method ChangeNickname
        /// change nickname on certain text
        /// </summary>
        /// <param name="textOfLetter"></param>
        /// <returns></returns>
        public ResponseLetterLogic ChangeNickname(string textOfLetter)
        {
            try
            {
                _mailRuUserInfo = new MailRuUserInfoPage(_driver);
                _mailRuUserInfo.ChangeNickname(textOfLetter);
                return this;
            }
            catch
            {
                throw new LetterException();
            }
        }

        /// <summary>
        /// method CheckResponseLetter
        /// check response letter on correctness
        /// </summary>
        /// <param name="textOfLetter"></param>
        /// <returns></returns>
        public bool CheckResponseLetter(string textOfLetter)
        {
            try
            {
                _mailRuMainPage.OpenUserInfo();
                var result = _mailRuUserInfo.CheckChangingNickName(textOfLetter);

                return result;
            }
            catch
            {
                throw new LetterException();
            }            
        }
    }
}