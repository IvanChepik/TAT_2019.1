using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Models;

namespace DataBases
{
    public class Supplies
    {
        public string FileName { get; set; }

        public string XmlFilename { get; set; }

        private List<Supply> _suppliesList;

        public event Action<string, List<Supply>, string> Added;

        public Supplies(string filename, string xmlFilename)
        {
            XmlFilename = xmlFilename;
            FileName = filename;
            this.InitDataBase(FileName);
        }

        public void AddNewSupply(Supply supply)
        {
            _suppliesList.Add(supply);
            OnAdded();
        }

        private void OnAdded()
        {
            Added?.Invoke(FileName, _suppliesList, XmlFilename);
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