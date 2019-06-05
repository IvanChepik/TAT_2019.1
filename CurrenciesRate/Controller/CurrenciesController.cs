namespace Controller
{
    public class CurrenciesController
    {
        public void WriteCurrencies(string filename, string driverName)
        {
            var writer = new WriterFactory().CreateWriter(filename);
        }
    }
}