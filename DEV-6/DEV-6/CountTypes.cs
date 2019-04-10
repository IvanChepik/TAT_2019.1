using System;

namespace DEV_6
{
    public class CountTypes : ICommand
    {
        private readonly CarCatalog _carCatalog;

        public CountTypes(CarCatalog carCatalog)
        {
            _carCatalog = carCatalog;
        }

        public void Execute()
        {
            var count = _carCatalog.CountTypes();
            Console.WriteLine(count);
        }
    }
}