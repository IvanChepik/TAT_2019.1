using System;

namespace DEV_6
{
    /// <summary>
    /// Class Vehicle
    /// included common fields for all vehicle.
    /// </summary>
    public class Vehicle
    {
        private readonly int _minAmount = -1;

        private readonly double _minPrice = 0;

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        /// <summary>
        /// Constructor Vehicle
        /// set a fields for our vehicle.
        /// </summary>
        /// <param name="brand">brand of vehicle</param>
        /// <param name="model">model of vehicle</param>
        /// <param name="amount">amount of vehicle</param>
        /// <param name="price">price of vehicle</param>
        public Vehicle(string brand, string model, int amount, double price)
        {
            if ((brand == string.Empty) || (model == string.Empty) || (amount < this._minAmount) || (price <= this._minPrice))
            {
                throw new ArgumentException("Wrong argument.");
            }

            this.Brand = brand;
            this.Model = model;
            this.Amount = amount;
            this.Price = price;
        }
    }
}
