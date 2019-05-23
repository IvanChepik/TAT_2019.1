using System;
using System.Collections.Generic;
using System.IO;
using DataBases;
using Models;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Controller
{
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
            Addresses = new Addresses(_files[0]);
            Stocks = new Stocks(_files[1]);
            Producers = new Producers(_files[2]);
            Products = new Products(_files[3]);
            Supplies = new Supplies(_files[4]);

            Addresses.Added += this.Update;
            Stocks.Added += this.Update;
            Producers.Added += this.Update;
            Products.Added += this.Update;
            Supplies.Added += this.Update;
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

        private void Update(string filename)
        {
            var json = JsonConvert.SerializeObject(Addresses.GetAll());

            using (var fileStream = new StreamWriter(filename, false, System.Text.Encoding.Default))
            {
                fileStream.Write(json);
            }

            var formatter = new XmlSerializer(typeof(Address));

            using (FileStream fs = new FileStream("address.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Addresses.GetAll()[0]);
            }

        }
    }
}