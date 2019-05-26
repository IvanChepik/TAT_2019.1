using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Producer
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int IdAddress { get; set; }

        [DataMember]
        public string Country { get; set; }

        public Producer()
        {

        }

        public Producer(int id, string name, int idAddress, string country)
        {
            Id = id;
            Name = name;
            IdAddress = idAddress;
            Country = country;
        }
    }
}