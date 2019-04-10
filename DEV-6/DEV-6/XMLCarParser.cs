using System;
using System.Collections.Generic;
using System.Xml;

namespace DEV_6
{
    public class XmlCarParser
    {
        private readonly List<Car> _listCars;

        public XmlCarParser()
        {
            _listCars = new List<Car>();
        }

        public List<Car> GetGarFromDocument(string path)
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