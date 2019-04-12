using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DEV_6
{
    /// <summary>
    /// Class XmlCarParser
    /// Parse data of our Xml File to ListCar.
    /// </summary>
    public class XmlCarParser
    {
        private static XmlCarParser _instance;

        /// <summary>
        /// Constructor XmlCarParser
        /// private constructor for singletone
        /// </summary>
        private XmlCarParser()
        {
        }

        /// <summary>
        /// Method GetInstance
        /// method for get one object of this type.
        /// </summary>
        /// <returns>Object of this type</returns>
        public static XmlCarParser GetInstance()
        {
            return _instance ?? (_instance = new XmlCarParser());
        }

        /// <summary>
        /// Method GetCarsFromDocument
        /// get all cars from xml file 
        /// </summary>
        /// <param name="path">path to xml file</param>
        /// <returns>List of cars from xml file</returns>
        public List<Vehicle> GetVehiclesFromDocument(string path)
        {
            var xmlDocument = XDocument.Load(path);
            var listVehicles = xmlDocument.Element("vehicles")
                ?.Elements("vehicle").Select(e => new Vehicle(
                    e.Element("brand")?.Value ?? throw new XmlException("Wrong xml file"), 
                    e.Element("model")?.Value ?? throw new XmlException("Wrong xml file"),
                    int.Parse(e.Element("amount")?.Value ?? throw new XmlException("Wrong xml file")),
                    double.Parse(e.Element("price")?.Value ?? throw new XmlException("Wrong xml file"))))
                .ToList();
            return listVehicles;
        }
    }
}