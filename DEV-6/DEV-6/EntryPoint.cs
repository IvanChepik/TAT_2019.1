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
                var carsFile = new XmlCarParser();
                var carsList = carsFile.GetCarsFromDocument(args[0]);
                var menu = new Menu(new CarCatalog(carsList));
                menu.Show();
            }
            catch (ArgumentException e)
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
