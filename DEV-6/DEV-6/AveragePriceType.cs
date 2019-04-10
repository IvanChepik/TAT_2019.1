using System;

namespace DEV_6
{
    public class AveragePriceType : ICommand
    {
        private readonly CarCatalog _carCatalog;

        private readonly string _brand;

        public AveragePriceType(CarCatalog carCatalog, string brand)
        {
            _brand = brand;
            _carCatalog = carCatalog;
        }

        public void Execute()
        {
            var averagePrice = _carCatalog.GetAveragePriceType(_brand);
            Console.WriteLine(averagePrice);
        }
    }
}