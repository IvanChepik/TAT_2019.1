namespace Models
{
    /// <summary>
    /// Class Currency
    /// model currency
    /// </summary>
    public class Currency
    {
        public string Name { get; }

        public string Value { get; }

        public Currency(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}