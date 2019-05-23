using System;
using System.Collections.Generic;

namespace Controller
{
    public class Shop
    {
        public DataStorage DataStorage { get; set; }

        public Shop()
        {
            DataStorage = new DataStorage();
            //Console.WriteLine(DataStorage.Addresses.GetAll()[0].Country);
        }

        public void AddAddresses(int id, string city, string street, int houseNumber, string country)
        {
            DataStorage.AddAddress(id, city, street, houseNumber, country);
        }

        public void AddStock(int id, string name, int idAddress)
        {
            DataStorage.AddStock(id, name, idAddress);
        }

        public void AddProduct(int id, string name, int count, int idProducer,int idStock, int idSupply, string dateOfManufacture)
        {
            DataStorage.AddProduct(id, name, count, idProducer, idStock, idSupply, dateOfManufacture);
        }

        public void AddSupply(int id, string date, string description)
        {
            DataStorage.AddSupply(id, date, description);
        }

        public void AddProducer(int id, string country, int idAddress, string name)
        {
            DataStorage.AddProducer(id, country, idAddress, name);
        }

    }
}