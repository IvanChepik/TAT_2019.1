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

        private List<Producer> _producersList;

        public event Action<string> Added;

        public Producers(string filename)
        {
            FileName = filename;
            this.InitDataBase(FileName);
        }

        public void AddNewProducer(Producer producer)
        {
            _producersList.Add(producer);
            OnAdded();
        }

        public List<Producer> GetAll()
        {
            return _producersList;
        }

        private void OnAdded()
        {
            Added?.Invoke(FileName);
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