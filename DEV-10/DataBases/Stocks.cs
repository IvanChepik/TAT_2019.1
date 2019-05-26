using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Models;

namespace DataBases
{
    /// <summary>
    /// Class Stocks
    /// Includes list of stock
    /// </summary>
    public class Stocks
    {
        public string FileName { get; set; }

        public string XmlFileName { get; set; }

        private List<Stock> _stocksList;

        public event Action<string, List<Stock>, string> Changed;

        public Stocks(string fileName, string xmlFileName)
        {
            this.XmlFileName = xmlFileName;
            this.FileName = fileName;
            this.InitDataBase(FileName);
        }

        public void AddNewStock(Stock stock)
        {
            this._stocksList.Add(stock);
            this.OnAdded();
        }

        public void DeleteById(int id)
        {
            this._stocksList.RemoveAll(x => x.Id == id);
        }

        private void InitDataBase(string file)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Stock>));

            using (var fs = new FileStream(file, FileMode.Open))
            {
                this._stocksList = (List<Stock>)jsonFormatter.ReadObject(fs);
            }
        }

        private void OnAdded()
        {
            this.Changed?.Invoke(FileName, _stocksList, XmlFileName);
        }
    }
}