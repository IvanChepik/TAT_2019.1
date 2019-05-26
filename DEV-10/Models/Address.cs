using System.Runtime.Serialization;

namespace Models
{
    /// <summary>
    /// Class Address
    /// address model
    /// </summary>
    [DataContract]
    public class Address
    {
        private int _minId = 1;

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

        /// <summary>
        /// Constructor Address
        /// constructor for xml parsing
        /// </summary>
        public Address()
        {

        }

        /// <summary>
        /// Constructor Address
        /// constructor for creating new entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="city"></param>
        /// <param name="street"></param>
        /// <param name="houseNumber"></param>
        /// <param name="country"></param>
        public Address(int id, string city, string street, int houseNumber, string country)
        {
            if (id < _minId)
            {
                throw new DataTypeException("Wrong id");
            }

            this.Id = id;
            this.City = city;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.Country = country;
        }
    }
}