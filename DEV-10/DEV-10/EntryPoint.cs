using System;
using Controller;
using Models;

namespace DEV_10
{
    /// <summary>
    /// Class EntryPoint
    /// entry point of program.
    /// </summary>
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            try
            {
                var shop = new Shop();
                shop.AddAddresses(1, "MINSK", "SERP", 2, "RUSSIA");
                shop.AddProduct(4, "HELLO", 4, 2, 6, 8, "24.02.1332");
                shop.AddAddresses(5, "Voland", "Serpuh", 4, "Poland");
                shop.DeleteById(3, Databases.Addresses);
            }
            catch (DataTypeException e)
            {
                Console.WriteLine("WRONG DATA TYPE : " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
