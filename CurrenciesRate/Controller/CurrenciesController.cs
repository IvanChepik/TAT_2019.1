using System.Collections.Generic;
using Models;
using Pages;

namespace Controller
{
    /// <summary>
    /// Class CurrenciesController
    /// manage work with other services
    /// </summary>
    public class CurrenciesController
    {
        public void WriteCurrencies(string filename, string driverName)
        {
            var currencies = new List<Currency>();
            var info = GetInfo(driverName);

            foreach (var currency in info)
            {
                currencies.Add(new Currency(currency.Key, currency.Value));
            }

            var writer = new WriterFactory().CreateWriter(filename);

            writer.WriteInFile(filename, currencies);
        }

        private Dictionary<string, string> GetInfo(string driverName)
        {
            var driver = new DriverFactory().CreateDriver(driverName);
            var page = new MainPage(driver);
            return page.GetData();
        }
    }
}