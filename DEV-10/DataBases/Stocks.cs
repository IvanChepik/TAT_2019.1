using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Models;

namespace DataBases
{
    public class Stocks
    {
        public string FileName { get; set; }

        public string XmlFileName { get; set; }

        private List<Stock> _stocksList;

        public event Action<string, List<Stock>, string> Added;

        public Stocks(string fileName, string xmlFileName)
        {
            XmlFileName = xmlFileName;
            FileName = fileName;
            this.InitDataBase(FileName);
        }

        public void AddNewStock(Stock stock)
        {
            _stocksList.Add(stock);
            OnAdded();
        }

        private void InitDataBase(string file)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Stock>));
            using (var fs = new FileStream(file, FileMode.Open))
            {
                _stocksList = (List<Stock>)jsonFormatter.ReadObject(fs);
            }
        }

        private void OnAdded()
        {
            Added?.Invoke(FileName, _stocksList, XmlFileName);
        }
    }
}