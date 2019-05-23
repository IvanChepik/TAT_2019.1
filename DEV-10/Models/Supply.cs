using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Supply : Model
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Date { get; set; }

        public Supply(int id, string description, string date)
        {
            Id = id;
            Description = description;
            Date = date;
        }
    }
}