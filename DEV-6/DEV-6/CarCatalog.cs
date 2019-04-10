using System.Collections.Generic;
using System.Linq;

namespace DEV_6
{
    /// <summary>
    /// Car Catalog
    /// Executor of command.
    /// </summary>
    public class CarCatalog
    {
        private readonly List<Car> _carsList;

        /// <summary>
        /// Construtor CarCatalog
        /// set a private readonly field.
        /// </summary>
        /// <param name="cars"></param>
        public CarCatalog(List<Car> cars)
        {
            _carsList = cars;
        }

        /// <summary>
        /// Method GetAveragePrice
        /// calculate and return average price of all cars.
        /// </summary>
        /// <returns>average price of all cars.</returns>
        public double GetAveragePrice()
        {
            return _carsList.Select(e => e.Price).Average();
        }

        /// <summary>
        /// Method GetAveragePriceType
        /// calculate and return average price of all cars of one type.
        /// </summary>
        /// <returns>average price of all cars of one type.</returns>
        public double GetAveragePriceType(string brand)
        {
            
            if (!_carsList.Select(e => e.Brand).Contains(brand))
            {
                throw new NoTypeCarException("Catalog doesn't contains this type");    
            }
            return _carsList.Where(e => e.Brand == brand).Select(e => e.Price).Average();
                 
        }

        /// <summary>
        /// Method CountTypes
        /// calculate and return number of all types
        /// </summary>
        /// <returns>number of all types</returns>
        public int CountTypes()
        {
            return _carsList.GroupBy(e => e.Brand).Count();
        }

        /// <summary>
        /// Method CountTypes
        /// calculate and return number of all cars.
        /// </summary>
        /// <returns>number of all cars</returns>
        public int CountCars()
        {
            return _carsList.Select(i => i.Amount).Sum(e => e);
        }
    }
}