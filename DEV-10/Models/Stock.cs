using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Stock
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int IdAddress { get; set; }

        public Stock()
        {

        }

        public Stock(int id, string name, int idAddress)
        {
            Id = id;
            Name = name;
            IdAddress = idAddress;
        }
    }
}