using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Models;

namespace DataBases
{
    /// <summary>
    /// Class Supplies
    /// includes list of supplies
    /// </summary>
    public class Supplies
    {
        public string FileName { get; set; }

        public string XmlFilename { get; set; }

        private List<Supply> _suppliesList;

        public event Action<string, List<Supply>, string> Changed;

        public Supplies(string filename, string xmlFilename)
        {
            this.XmlFilename = xmlFilename;
            this.FileName = filename;
            this.InitDataBase(FileName);
        }

        public void AddNewSupply(Supply supply)
        {
            this._suppliesList.Add(supply);
            this.OnChanged();
        }

        public void DeleteById(int id)
        {
            this._suppliesList.RemoveAll(x => x.Id == id);
            this.OnChanged();
        }

        private void OnChanged()
        {
            this.Changed?.Invoke(FileName, _suppliesList, XmlFilename);
        }

        private void InitDataBase(string file)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Supply>));

            using (var fs = new FileStream(file, FileMode.Open))
            {
                this._suppliesList = (List<Supply>)jsonFormatter.ReadObject(fs);
            }
        }
    }
}