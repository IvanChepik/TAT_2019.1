using System.Runtime.Serialization;

namespace Models 
{
    /// <summary>
    /// Class Product
    /// model product
    /// </summary>
    [DataContract]
    public class Product 
    {
        private int _minId = 1;

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
        /// <summary>
        /// Constructor Product
        /// Constructor for xml parsing
        /// </summary>
        public Product()
        {

        }

        /// <summary>
        /// Constructor Product
        /// Constructor for creating new entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="count"></param>
        /// <param name="idProducer"></param>
        /// <param name="idStock"></param>
        /// <param name="idSupply"></param>
        /// <param name="dateOfManufacture"></param>
        public Product(int id, string name, int count, int idProducer, int idStock, int idSupply,
            string dateOfManufacture)
        {

            if (id < _minId || idProducer < _minId || idStock < _minId || idSupply < _minId)
            {
                throw  new DataTypeException("Wrong Id");
            }

            this.Id = id;
            this.Name = name;
            this.Count = count;
            this.IdProducer = idProducer;
            this.IdStock = idStock;
            this.IdSupply = idSupply;
            this.DateOfManufacture = dateOfManufacture;
        }
    }
}