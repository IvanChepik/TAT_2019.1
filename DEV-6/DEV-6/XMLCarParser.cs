using System;
using System.Collections.Generic;
using System.Xml;

namespace DEV_6
{
    /// <summary>
    /// Class XmlCarParser
    /// Parse data of our Xml File to ListCar.
    /// </summary>
    public class XmlCarParser
    {
        private readonly List<Car> _listCars;

        /// <summary>
        /// Constructor XmlParser
        /// create new List object.
        /// </summary>
        public XmlCarParser()
        {
            _listCars = new List<Car>();
        }

        /// <summary>
        /// Method GetCarsFromDocument
        /// get all cars from xml file 
        /// </summary>
        /// <param name="path">path to xml file</param>
        /// <returns>List of cars from xml file</returns>
        public List<Car> GetCarsFromDocument(string path)
        {
            _listCars.Clear();
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            var xmlRoot = xmlDocument.DocumentElement;

            foreach (XmlNode xmlNode in xmlRoot ?? throw new ArgumentException("XML file is empty"))
            {
                _listCars.Add(GetCar(xmlNode));
            }


            return _listCars;
        }

        /// <summary>
        /// Method GetCar
        /// Create and return new car from XmlChildNodes
        /// </summary>
        /// <param name="xmlNode">Xml nodes which included childnodes and inner text</param>
        /// <returns>object car from data in xml file</returns>
        private Car GetCar(XmlNode xmlNode)
        {
            var brand = string.Empty;
            var model = string.Empty;
            var amount = 0;
            var price = 0.0;

            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                try
                {
                    switch (childNode.Name)
                    {
                        case "brand":
                            brand = childNode.InnerText;
                            break;
                        case "model":
                            model = childNode.InnerText;
                            break;
                        case "amount":
                            amount = int.Parse(childNode.InnerText);
                            break;
                        case "price":
                            price = double.Parse(childNode.InnerText);
                            break;
                    }
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException("Wrong data in XML file");
                }               
            }

            return new Car(brand, model, amount, price);
        }
    }
}