using System.Runtime.Serialization;

namespace Models
{
    /// <summary>
    /// Class Supply
    /// Model of supply
    /// </summary>
    [DataContract]
    public class Supply
    {
        private int _minId = 1;

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Date { get; set; }

        /// <summary>
        /// Constructor Supply
        /// constructor for xml parsing
        /// </summary>
        public Supply()
        {

        }

        /// <summary>
        /// Constructor Supply
        /// Constructor for creating new entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="date"></param>
        public Supply(int id, string description, string date)
        {
            if (id < _minId)
            {
                throw new DataTypeException("Wrong id");
            }

            this.Id = id;
            this.Description = description;
            this.Date = date;
        }
    }
}