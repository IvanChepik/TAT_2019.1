using System.Collections.Generic;
using System.Linq;

namespace DEV_6
{
    /// <summary>
    /// Class VehiclesCatalog
    /// Executor of command.
    /// </summary>
    public class VehiclesCatalog
    {
        private readonly List<Vehicle> _vehiclesList;

        /// <summary>
        /// Constructor VehiclesCatalog
        /// set a private readonly field.
        /// </summary>
        /// <param name="vehicles"></param>
        public VehiclesCatalog(List<Vehicle> vehicles)
        {
            _vehiclesList = vehicles;
        }

        /// <summary>
        /// Method GetAveragePrice
        /// calculate and return average price of all vehicles.
        /// </summary>
        /// <returns>average price of all cars.</returns>
        public double GetAveragePrice()
        {
            return _vehiclesList.Select(e => e.Price).Average();
        }

        /// <summary>
        /// Method GetAveragePriceType
        /// calculate and return average price of all vehicles of one type.
        /// </summary>
        /// <returns>average price of all vehicles of one type.</returns>
        public double GetAveragePriceType(string brand)
        {
            
            if (!_vehiclesList.Select(e => e.Brand).Contains(brand))
            {
                throw new NoTypeCarException("Catalog doesn't contains this type");    
            }
            return _vehiclesList.Where(e => e.Brand == brand).Select(e => e.Price).Average();
                 
        }

        /// <summary>
        /// Method CountTypes
        /// calculate and return number of all types
        /// </summary>
        /// <returns>number of all types</returns>
        public int CountTypes()
        {
            return _vehiclesList.GroupBy(e => e.Brand).Count();
        }

        /// <summary>
        /// Method CountTypes
        /// calculate and return number of all vehicles.
        /// </summary>
        /// <returns>number of all cars</returns>
        public int CountVehicles()
        {
            return _vehiclesList.Select(i => i.Amount).Sum(e => e);
        }
    }
}