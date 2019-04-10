using System;

namespace DEV_6
{
    public class CountAll : ICommand
    {

        private readonly CarCatalog _carCatalog;

        public CountAll(CarCatalog carCatalog)
        {
            _carCatalog = carCatalog;
        }
        public void Execute()
        {
            var count = _carCatalog.CountCars();
            Console.WriteLine(count);
        }
    }
}