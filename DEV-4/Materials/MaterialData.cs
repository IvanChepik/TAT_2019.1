namespace Materials
{
    /// <summary>
    /// Class MaterialData
    /// has guid and information of all entitiy
    /// </summary>
    public class MaterialData
    {
        private string _information;
        public string Guid { get; }

        public string Information
        {
            get => _information;

            set
            {
                if (value.Length > 256)
                {
                    throw new WrongLengthException("Your information is longer than 256 characters");
                }

                _information = value;
            }
        }

        public MaterialData(string information)
        {
            Guid = Guid.GetId();
            Information = information;
        }

        public MaterialData(string information, string guid)
        {
            Guid = guid;
            Information = information;
        }
    }
}