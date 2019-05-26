using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Models;

namespace DataBases
{
    public class Products
    {
        public string FileName { get; set; }

        public string XmlFileName { get; set; }

        private List<Product> _productsList;
        
        public Products(string filename, string xmlFileName)
        {
            XmlFileName = xmlFileName;
            FileName = filename;
            this.InitDataBase(FileName);
        }

        public List<Product> GetAll()
        {
            return _productsList;
        }

        public void AddNewProduct(Product product)
        {
            _productsList.Add(product);
            OnAdded();
        }

        private void InitDataBase(string file)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Product>));
            using (var fs = new FileStream(file, FileMode.Open))
            {
                _productsList = (List<Product>)jsonFormatter.ReadObject(fs);
            }
        }

        public event Action<string, List<Product>, string> Added;

        private void OnAdded()
        {
            Added?.Invoke(FileName, _productsList, XmlFileName);
        }
    }
}