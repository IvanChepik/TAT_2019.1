using System.IO;
using DataBases;
using Models;
using Newtonsoft.Json;

namespace Controller
{
    public class DataStorage
    {
        public Addresses Addresses { get; set; }
        
        public Stocks Stocks { get; set; }

        public Producers Producers { get; set; }

        public Products Products { get; set; }

        public Supplies Supplies { get; set; }

        public DataStorage()
        {
            InitStorage();
        }

        private void InitStorage()
        {

            Addresses = GetObjectFromFile<Addresses>("Addresses.json");
            //Producers = GetObjectFromFile<Producer>("Producers.json");
            //Products = GetObjectFromFile<Product>("Products.json");
            //Stocks = GetObjectFromFile<Stock>("Stocks.json");
            //Supplies = GetObjectFromFile<Supply>("Supplies.json");
        }

        private T GetObjectFromFile<T>(string fileName)
        {
            return JsonConvert.DeserializeObject<T>(GetTextFromFile(fileName));
        }

        private string GetTextFromFile(string fileName)
        {
            var textFile = new StreamReader(fileName).ReadToEnd();
            return textFile;
        }
    }
}