using System;

namespace DEV_6
{
    public class AveragePriceAll : ICommand
    {
        private readonly CarCatalog _carCatalog;

        public AveragePriceAll(CarCatalog carCatalog)
        {
            _carCatalog = carCatalog;
        }

        public void Execute()
        {
            var averagePrice = _carCatalog.GetAveragePrice();
            Console.WriteLine(averagePrice);
        }
    }
}