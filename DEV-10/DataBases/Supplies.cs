using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Models;
using Newtonsoft.Json;

namespace DataBases
{
    public class Supplies
    {
        public string FileName { get; set; }

        public List<Supply> _suppliesList { get; set; }

        public event Action<string> Added;

        public Supplies(string filename)
        {
            FileName = filename;
            this.InitDataBase(FileName);
        }

        public List<Supply> GetAll()
        {
            return _suppliesList;
        }

        public void AddNewSupply(Supply supply)
        {
            _suppliesList.Add(supply);
            OnAdded();
        }

        private void OnAdded()
        {
            Added?.Invoke(FileName);
        }

        private void InitDataBase(string file)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Supply>));
            using (var fs = new FileStream(file, FileMode.Open))
            {
                _suppliesList = (List<Supply>)jsonFormatter.ReadObject(fs);
            }
        }
    }
}