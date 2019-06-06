using System;
using Controller;

namespace CurrenciesRate
{
    /// <summary>
    /// Class EntryPoint
    /// Read currencies rate from site and write it in file
    /// </summary>
    public class EntryPoint
    {
        /// <summary>
        /// Method Main
        /// entry point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            try
            {
                var controller = new CurrenciesController();
                controller.WriteCurrencies("currencies.json", "Firefox");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }            
        }
    }
}
