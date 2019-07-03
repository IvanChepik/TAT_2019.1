using System;

namespace DEV_6
{
    /// <summary>
    /// Class CountTypes
    /// class command for count all types of cars.
    /// </summary>
    public class CountTypes : ICommand
    {
        private readonly CarCatalog _carCatalog;

        /// <summary>
        /// Constructor CountTypes
        /// set a private readonly field of our class.
        /// </summary>
        /// <param name="carCatalog"></param>
        public CountTypes(CarCatalog carCatalog)
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
            var count = _carCatalog.CountTypes();
            OnRequested(count);
        }

        /// <summary>
        /// Method OnRequested
        /// calls method event.
        /// </summary>
        /// <param name="count">count of types</param>
        private void OnRequested(int count)
        {
            Requested?.Invoke(this, count.ToString());
        }
    }
}