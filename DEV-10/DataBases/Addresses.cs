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

        private List<Address> _addressesList;

        public void AddNewAddress(Address address)
        {
            _addressesList.Add(address);
            OnAdded();
        }

        public Addresses(string filename)
        {
            FileName = filename;
            this.InitDataBase(FileName);
        }

        private void InitDataBase(string file)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Address>));
            using (var fs = new FileStream(file, FileMode.Open))
            {
                _addressesList = (List<Address>) jsonFormatter.ReadObject(fs);
            }
        }

        public List<Address> GetAll()
        {
            return _addressesList;
        }
        
        public event Action<string> Added;

        private void OnAdded()
        {
            Added?.Invoke(FileName);
        }
    }
}