using System.IO;
using System.Xml.Serialization;

namespace Writers
{
    /// <summary>
    /// Class XmlWriter
    /// write data in xml file
    /// </summary>
    public class XmlWriter : Writer
    {
        /// <summary>
        /// Method WriteInFile
        /// write data from list to filename
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"></param>
        /// <param name="list"></param>
        public override void WriteInFile<T>(string filename, T list)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, list);
            }
        }
    }
}