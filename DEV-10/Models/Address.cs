using System;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Address : Model
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string Street { get; set; }

        [DataMember]
        public int HouseNumber { get; set; }

        [DataMember]
        public string Country { get; set; }       

        public Address(int id, string city, string street, int houseNumber, string country)
        {
            Id = id;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            Country = country;
        }
    }
}