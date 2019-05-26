using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Models;

namespace DataBases
{
    /// <summary>
    /// Class Products
    /// includes products List
    /// </summary>
    public class Products
    {
        public string FileName { get; set; }

        public string XmlFileName { get; set; }

        private List<Product> _productsList;
        
        public Products(string filename, string xmlFileName)
        {
            this.XmlFileName = xmlFileName;
            this.FileName = filename;
            this.InitDataBase(FileName);
        }

        public void AddNewProduct(Product product)
        {
            this._productsList.Add(product);
            this.OnAdded();
        }

        public void DeleteById(int id)
        {
            this._productsList.RemoveAll(x => x.Id == id);
        }

        private void InitDataBase(string file)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Product>));

            using (var fs = new FileStream(file, FileMode.Open))
            {
                this._productsList = (List<Product>)jsonFormatter.ReadObject(fs);
            }
        }

        public event Action<string, List<Product>, string> Changed;

        private void OnAdded()
        {
            this.Changed?.Invoke(FileName, _productsList, XmlFileName);
        }
    }
}