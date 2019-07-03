using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Models;

namespace DataBases
{
    /// <summary>
    /// Class Producers
    /// includes list of producers
    /// </summary>
    public class Producers
    {
        public string FileName { get; set; }

        public string XmlFileName { get; set; }

        private List<Producer> _producersList;

        public event Action<string, List<Producer>, string> Changed;

        public Producers(string filename, string xmlFileName)
        {
            this.XmlFileName = xmlFileName;
            this.FileName = filename;
            this.InitDataBase(FileName);
        }

        public void DeleteById(int id)
        {
            this._producersList.RemoveAll(x => x.Id == id);
        }

        public void AddNewProducer(Producer producer)
        {
            this._producersList.Add(producer);
            this.OnAdded();
        }

        private void OnAdded()
        {
            this.Changed?.Invoke(FileName, _producersList, XmlFileName);
        }

        private void InitDataBase(string file)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Producer>));
            using (var fs = new FileStream(file, FileMode.Open))
            {
                this._producersList = (List<Producer>)jsonFormatter.ReadObject(fs);
            }
        }
    }
}