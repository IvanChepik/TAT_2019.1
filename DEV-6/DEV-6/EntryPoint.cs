using System;

namespace DEV_6
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var carsFile = new XmlCarParser();

            var carsList = carsFile.GetGarFromDocument("Cars.xml");

            var menu = new Menu(new CarCatalog(carsList));

            menu.Show();

        }
    }
}
