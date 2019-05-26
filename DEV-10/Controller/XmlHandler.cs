using System.IO;
using System.Xml.Serialization;

namespace Controller
{
    /// <summary>
    /// Class XmlHandler
    /// entity for working with xml files
    /// </summary>
    public class XmlHandler
    {
        public void WriteToXml<T>(string filename, T modelList)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, modelList);
            }
        }
    }
}