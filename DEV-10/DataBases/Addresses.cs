using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Models;

namespace DataBases
{
    public class Addresses
    {
        public string FileName { get; set; }

        public string XmlFilename { get; set; }

        private List<Address> _listAddresses;

        public void AddNewAddress(Address address)
        {
            _listAddresses.Add(address);
            OnAdded();
        }

        public Addresses(string filename, string xmlFilename)
        {
            XmlFilename = xmlFilename;
            FileName = filename;
            this.InitDataBase(FileName);
        }

        private void InitDataBase(string file)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Address>));
            using (var fs = new FileStream(file, FileMode.Open))
            {
                _listAddresses = (List<Address>) jsonFormatter.ReadObject(fs);
            }
        }

        public event Action<string, List<Address>, string> Added;

        private void OnAdded()
        {
            Added?.Invoke(FileName, _listAddresses, XmlFilename);
        }
    }
}