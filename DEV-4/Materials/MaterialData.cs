namespace Materials
{
    /// <summary>
    /// Class MaterialData
    /// included guid and information of all entity
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

        /// <summary>
        /// Constructor MaterialData
        /// set a information and generate new ID
        /// </summary>
        /// <param name="information"></param>
        public MaterialData(string information)
        {
            Guid = Guid.GetId();
            Information = information;
        }

        /// <summary>
        /// Constructor MaterialData
        /// for Copy
        /// </summary>
        /// <param name="information">information about entity</param>
        /// <param name="guid">id of entity</param>
        public MaterialData(string information, string guid)
        {
            Guid = guid;
            Information = information;
        }
    }
}