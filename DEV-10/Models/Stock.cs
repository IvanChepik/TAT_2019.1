using System.Runtime.Serialization;

namespace Models
{
    /// <summary>
    /// Class Stock
    /// model stock
    /// </summary>
    [DataContract]
    public class Stock
    {
        private int _minId = 1;

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int IdAddress { get; set; }

        /// <summary>
        /// Constructor Stock
        /// Constructor for xml parsing
        /// </summary>
        public Stock()
        {

        }

        /// <summary>
        /// Constructor Stock
        /// constructor for creating new entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="idAddress"></param>
        public Stock(int id, string name, int idAddress)
        {
            if (id < _minId || idAddress < _minId)
            {
                throw new DataTypeException("Wrong id");
            }

            this.Id = id;
            this.Name = name;
            this.IdAddress = idAddress;
        }
    }
}