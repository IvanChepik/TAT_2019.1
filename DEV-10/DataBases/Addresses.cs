using System.Collections.Generic;
using System.IO;
using Models;
using Newtonsoft.Json;

namespace DataBases
{
    public class Addresses
    {
        [JsonProperty("AddressesList")]
        public List<Address> AddressesList { get; set; }

    }
}