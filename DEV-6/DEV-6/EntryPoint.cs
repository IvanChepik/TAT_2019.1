using System;

namespace DEV_6
{
    /// <summary>
    /// Class EntryPoint
    /// parse XML file and do different operation with this data.
    /// </summary>
    public class EntryPoint
    {
        /// <summary>
        /// Method Main
        /// entry point.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            try
            {
                var vehicleFile = XmlCarParser.GetInstance();
                var carsList = vehicleFile.GetVehiclesFromDocument(args[0]);
                var trucksList = vehicleFile.GetVehiclesFromDocument(args[1]);
                var menu = new Menu(new VehiclesCatalog(carsList), new VehiclesCatalog(trucksList));
                menu.Show();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (XmlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NoTypeCarException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
