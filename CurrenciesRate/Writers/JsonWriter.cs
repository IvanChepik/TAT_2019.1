using System.IO;
using Newtonsoft.Json;

namespace Writers
{
    /// <summary>
    /// Class JsonWriter
    /// write data in json file
    /// </summary>
    public class JsonWriter : Writer
    {
        /// <summary>
        /// Method WriteInFile
        /// write data from list to json filename
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"></param>
        /// <param name="list"></param>
        public override void WriteInFile<T>(string filename, T list)
        {
            var json = JsonConvert.SerializeObject(list);

            using (var fileStream = new StreamWriter(filename, false, System.Text.Encoding.Default))
            {
                fileStream.Write(json);
            }
        }
    }
}