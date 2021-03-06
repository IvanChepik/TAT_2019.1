﻿using System;

namespace DEV_6
{
    /// <summary>
    /// Class CountAll
    /// class command for count all cars
    /// </summary>
    public class CountAll : ICommand
    {
        private readonly VehiclesCatalog _carCatalog;

        /// <summary>
        /// Constructor CountAll
        /// set a private readonly field.
        /// </summary>
        /// <param name="carCatalog"></param>
        public CountAll(VehiclesCatalog carCatalog)
        {
            this._carCatalog = carCatalog;
        }

        public event EventHandler<string> Requested;

        /// <summary>
        /// Method Execute.
        /// calls method from another class and event.
        /// </summary>
        public void Execute()
        {
            var count = this._carCatalog.CountVehicles();
            this.OnRequested(count);
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