using System;
using Writers;

namespace Controller
{
    /// <summary>
    /// Class WriterFactory
    /// Create new writer dependens with input argument 
    /// </summary>
    public class WriterFactory
    {
        /// <summary>
        /// Method CreateWriter
        /// create writer by filename
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public Writer CreateWriter(string filename)
        {
            switch (GetWriterType(filename))
            {
                case WriterType.Xml:
                    return new XmlWriter();
                case WriterType.Json:
                    return new JsonWriter();
                default:
                    throw new ArgumentException("Wrong file type");
            }
        }


        private WriterType GetWriterType(string filename)
        {
            var type = filename.Split('.')[1];

            if (type.Equals("json"))
            {
                return WriterType.Json;
            }
            else if (type.Equals("xml"))
            {
                return WriterType.Xml;
            }

            throw new ArgumentException("Wrong writer type");
        }
    }
}