namespace Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public int IdProducer { get; set; }

        public int IdStock { get; set; }

        public int IdSupply { get; set; }

        public string DateOfManufacture { get; set; }
    }
}