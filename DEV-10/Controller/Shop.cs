using System;
using System.Collections.Generic;

namespace Controller
{
    public class Shop
    {
        private List<string> _files = new List<string>
        {
            "Addresses.json",
            "Stocks.json",
            "Producers.json",
            "Products.json",
            "Supplies.json"
        };

        public DataStorage DataStorage { get; set; }

        public Shop()
        {
           DataStorage = new DataStorage();
           Console.WriteLine(DataStorage.Addresses.AddressesList[0].Country);
        }

    }
}