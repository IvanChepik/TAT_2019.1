namespace Materials
{
    /// <summary>
    /// Class Presentation
    /// entity for class Lecture
    /// </summary>
    public class Presentation : Material
    {
        private string _url;
        public PresentationFormat PresentationFormat { get; }

        public string Url
        {
            get => _url;

            set
            {
                if (value.Length == 0)
                {
                    throw new WrongLengthException("Your url is empty");
                }

                _url = value;
            }
        }

        public Presentation(string url, string information, PresentationFormat presentationFormat) : base(information)
        {
            Url = url;
            PresentationFormat = presentationFormat;
        }
    }
}