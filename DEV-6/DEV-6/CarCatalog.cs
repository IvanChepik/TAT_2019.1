using System;
using System.Collections.Generic;
using System.Linq;

namespace DEV_6
{
    public class CarCatalog
    {
        private readonly List<Car> _carsList;

        public CarCatalog(List<Car> cars)
        {
            _carsList = cars;
        }

        public double GetAveragePrice()
        {
            return _carsList.Select(e => e.Price).Average();
        }

        public double GetAveragePriceType(string brand)
        {
            if (!_carsList.Select(e => e.Brand).Contains(brand))
            {
                throw new ArgumentException($"Catalog doesn't contain {brand}");
            }
            return _carsList.Where(e => e.Brand == brand).Select(e => e.Price).Average();
        }

        public int CountTypes()
        {
            return _carsList.GroupBy(e => e.Brand).Count();
        }

        public int CountCars()
        {
            return _carsList.Select(i => i.Amount).Sum();
        }
    }
}