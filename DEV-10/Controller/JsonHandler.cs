using System.IO;
using Newtonsoft.Json;

namespace Controller
{
    /// <summary>
    /// Class JsonHandler
    /// Entity for working with json files
    /// </summary>
    public class JsonHandler
    {
        public void WriteToJson<T>(string filename, T modelList)
        {
            var json = JsonConvert.SerializeObject(modelList);

            using (var fileStream = new StreamWriter(filename, false, System.Text.Encoding.Default))
            {
                fileStream.Write(json);
            }
        }
    }

}