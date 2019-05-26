using System.Collections.Generic;
using DataBases;
using Models;

namespace Controller
{
    /// <summary>
    /// Class DataStorage
    /// entity for working with databases
    /// </summary>
    public class DataStorage
    {
        private List<string> _files = new List<string>
        {
            "Addresses.json",
            "Stocks.json",
            "Producers.json",
            "Products.json",
            "Supplies.json"
        };

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
            Addresses = new Addresses(_files[0], "addresses.xml");
            Stocks = new Stocks(_files[1], "stocks.xml");
            Producers = new Producers(_files[2], "producers.xml");
            Products = new Products(_files[3], "products.xml");
            Supplies = new Supplies(_files[4], "supplies.xml");

            Addresses.Changed += this.Update;
            Stocks.Changed += this.Update;
            Producers.Changed += this.Update;
            Products.Changed += this.Update;
            Supplies.Changed += this.Update;
        }

        public void AddAddress(int id, string city, string street, int houseNumber, string country)
        {
            Addresses.AddNewAddress(new Address(id, city, street, houseNumber, country));
        }

        public void AddProduct(int id, string name, int count, int idProducer,int idStock, int idSupply, string dateOfManufacture)
        {
            Products.AddNewProduct(new Product(id, name, count, idProducer, idStock, idSupply, dateOfManufacture));
        }

        public void AddStock(int id, string name, int idAddress)
        {
            Stocks.AddNewStock(new Stock(id, name, idAddress));
        }

        public void AddSupply(int id, string date, string description)
        {
            Supplies.AddNewSupply(new Supply(id, description, date));
        }

        public void AddProducer(int id, string country, int idAddress, string name)
        {
            Producers.AddNewProducer(new Producer(id, name, idAddress, country));
        }

        public void DeleteById(int id, Databases database)
        {
            switch (database)
            {
                case Databases.Addresses:
                    this.Addresses.DeleteById(id);
                    break;
                case Databases.Producers:
                    this.Producers.DeleteById(id);
                    break;
                case Databases.Products:
                    this.Products.DeleteById(id);
                    break;
                case Databases.Stocks:
                    this.Stocks.DeleteById(id);
                    break;
                case Databases.Supplies:
                    this.Supplies.DeleteById(id);
                    break;
            }
        }

        private void Update<T>(string jsonfilename, T modelList, string xmlFilename)
        {
            var xmlHandler = new XmlHandler();
            xmlHandler.WriteToXml(xmlFilename, modelList);
            var jsonHandler = new JsonHandler();
            jsonHandler.WriteToJson(jsonfilename, modelList);
        }
    }
}