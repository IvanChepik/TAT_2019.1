using System.Runtime.Serialization;

namespace Models 
{
    [DataContract]
    public class Product 
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public int IdProducer { get; set; }

        [DataMember]
        public int IdStock { get; set; }

        [DataMember]
        public int IdSupply { get; set; }

        [DataMember]
        public string DateOfManufacture { get; set; }

        public Product()
        {

        }

        public Product(int id, string name, int count, int idProducer, int idStock, int idSupply,
            string dateOfManufacture)
        {
            Id = id;
            Name = name;
            Count = count;
            IdProducer = idProducer;
            IdStock = idStock;
            IdSupply = idSupply;
            DateOfManufacture = dateOfManufacture;
        }
    }
}