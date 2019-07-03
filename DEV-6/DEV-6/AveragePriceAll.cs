using System;

namespace DEV_6
{
    /// <summary>
    /// Class AveragePriceAll
    /// calculate the average price of all car.
    /// </summary>
    public class AveragePriceAll : ICommand
    {
        private readonly CarCatalog _carCatalog;

        /// <summary>
        /// Constructor AveragePriceAll
        /// set a fields for our class.
        /// </summary>
        /// <param name="carCatalog">list of cars</param>
        public AveragePriceAll(CarCatalog carCatalog)
        {
            _carCatalog = carCatalog;
        }

        public event EventHandler<string> Requested;

        /// <summary>
        /// Method Execute.
        /// calls method from another class and event.
        /// </summary>
        public void Execute()
        {
            var averagePrice = _carCatalog.GetAveragePrice();
            OnRequested(averagePrice);
        }

        /// <summary>
        /// Method OnRequested
        /// calls method event.
        /// </summary>
        /// <param name="averagePrice">count of types</param>
        private void OnRequested(double averagePrice)
        {
            Requested?.Invoke(this, averagePrice.ToString());
        }
    }
}