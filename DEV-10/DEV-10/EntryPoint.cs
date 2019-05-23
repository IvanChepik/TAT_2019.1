using System;
using Controller;
using Models;

namespace DEV_10
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {        
            var shop = new Shop();
            shop.AddAddresses(1, "MINSK", "SERP", 2, "RUSSIA");
            shop.AddProduct(4, "HELLO", 4, 2, 6, 8, "24.02.1332");
        }
    }
}
