using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Models;

namespace DataBases
{
    public class Producers
    {
        public string FileName { get; set; }

        public string XmlFileName { get; set; }

        private List<Producer> _producersList;

        public event Action<string, List<Producer>, string> Added;

        public Producers(string filename, string xmlFileName)
        {
            XmlFileName = xmlFileName;
            FileName = filename;
            this.InitDataBase(FileName);
        }

        public void AddNewProducer(Producer producer)
        {
            _producersList.Add(producer);
            OnAdded();
        }

        private void OnAdded()
        {
            Added?.Invoke(FileName, _producersList, XmlFileName);
        }

        private void InitDataBase(string file)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Producer>));
            using (var fs = new FileStream(file, FileMode.Open))
            {
                _producersList = (List<Producer>)jsonFormatter.ReadObject(fs);
            }
        }
    }
}