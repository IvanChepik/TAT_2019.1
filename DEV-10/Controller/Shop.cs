namespace Controller
{
    /// <summary>
    /// Class Shop
    /// Entity for working with storage
    /// </summary>
    public class Shop
    {
        public DataStorage DataStorage { get; set; }

        public Shop()
        {
            DataStorage = new DataStorage();
        }

        public void DeleteById(int id, Databases database)
        {
            DataStorage.DeleteById(id, database);
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