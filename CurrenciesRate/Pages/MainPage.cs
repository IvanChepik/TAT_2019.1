using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Pages
{
    /// <summary>
    /// Class MainPage
    /// Entity for main page of select.by
    /// </summary>
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement RowCurrencies =>
            Driver.FindElement(By.XPath("//tr[@class = 'tablesorter-hasChildRow odd']"));


        public ReadOnlyCollection<IWebElement> CurrenciesValue => RowCurrencies.FindElements(By.XPath("./td"));

        public Dictionary<string, string> GetData()
        {
            WaitForElementDisplayed(RowCurrencies);
            var data = new Dictionary<string, string>
            {
                {"Usd", CurrenciesValue[2].Text},
                {"Rub", CurrenciesValue[4].Text},
                {"Byn", CurrenciesValue[6].Text}
            };

            return data;
        }
    }
}


