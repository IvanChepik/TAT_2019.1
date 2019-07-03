using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Models;

namespace DataBases
{
    /// <summary>
    /// Class Addresses
    /// includes list of address
    /// </summary>
    public class Addresses
    {
        public string FileName { get; set; }

        public string XmlFilename { get; set; }

        private List<Address> _listAddresses;

        public void AddNewAddress(Address address)
        {
            this._listAddresses.Add(address);
            this.OnAdded();
        }

        public Addresses(string filename, string xmlFilename)
        {
            this.XmlFilename = xmlFilename;
            this.FileName = filename;
            this.InitDataBase(FileName);
        }

        private void InitDataBase(string file)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Address>));

            using (var fs = new FileStream(file, FileMode.Open))
            {
                this._listAddresses = (List<Address>) jsonFormatter.ReadObject(fs);
            }
        }

        public void DeleteById(int id)
        {
            this._listAddresses.RemoveAll(x => x.Id == id);
        }

        public event Action<string, List<Address>, string> Changed;

        private void OnAdded()
        {
            this.Changed?.Invoke(FileName, _listAddresses, XmlFilename);
        }
    }
}