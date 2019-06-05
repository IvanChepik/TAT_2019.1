using Controller;

namespace CurrenciesRate
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var controller = new CurrenciesController();
            controller.WriteCurrencies("currencies.json", "Firefox");
        }
    }
}
