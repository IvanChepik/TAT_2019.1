using System.Runtime.Serialization;

namespace Models
{
    /// <summary>
    /// Class Producer
    /// model producer
    /// </summary>
    [DataContract]
    public class Producer
    {
        private int _minId = 1;

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int IdAddress { get; set; }

        [DataMember]
        public string Country { get; set; }

        /// <summary>
        /// Constructor Producer
        /// constructor for xml parsing
        /// </summary>
        public Producer()
        {

        }

        /// <summary>
        /// Constructor Producer
        /// Constructor for creating new entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="idAddress"></param>
        /// <param name="country"></param>
        public Producer(int id, string name, int idAddress, string country)
        {
            if (id < _minId || idAddress < _minId)
            {
                throw  new DataTypeException("Wrong Id");
            }

            this.Id = id;
            this.Name = name;
            this.IdAddress = idAddress;
            this.Country = country;
        }
    }
}