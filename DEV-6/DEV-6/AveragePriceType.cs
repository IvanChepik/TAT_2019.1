using System;

namespace DEV_6
{
    /// <summary>
    /// Class AveragePriceType
    /// calculate the average price of one type.
    /// </summary>
    public class AveragePriceType : ICommand
    {
        private readonly CarCatalog _carCatalog;

        private readonly string _brand;

        public event EventHandler<string> Requested;

        /// <summary>
        /// Constructor AveragePriceType
        /// set a fields for our class.
        /// </summary>
        /// <param name="carCatalog">list of cars</param>
        /// <param name="brand">brand of car</param>
        public AveragePriceType(CarCatalog carCatalog, string brand)
        {
            _brand = brand;
            _carCatalog = carCatalog;
        }

        /// <summary>
        /// Method Execute.
        /// calls method from another class and event.
        /// </summary>
        public void Execute()
        {
            var averagePrice = _carCatalog.GetAveragePriceType(_brand);
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