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

        private List<Stock> _stocksList;

        public event Action<string> Added;

        public Stocks(string fileName)
        {
            FileName = fileName;
            this.InitDataBase(FileName);
        }

        public List<Stock> GetAll()
        {
            return _stocksList;
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
            Added?.Invoke(FileName);
        }
    }
}