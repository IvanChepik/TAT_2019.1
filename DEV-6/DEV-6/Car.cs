using System;

namespace DEV_6
{
    /// <summary>
    /// Class Car
    /// model of real life, included different fields and methods.
    /// </summary>
    public class Car
    {

        public string Brand { get;   }

        public string Model { get;  }

        public int Amount { get;  }

        public double Price { get; }

        /// <summary>
        /// Constructor Car
        /// set a fields for our car.
        /// </summary>
        /// <param name="brand">brand of car</param>
        /// <param name="model">model of car</param>
        /// <param name="amount">amount of car</param>
        /// <param name="price">price of car</param>
        public Car(string brand, string model, int amount, double price)
        {
            if ((brand == string.Empty) || (model == string.Empty) || (amount < -1) || (price <= 0))
            {
                throw new ArgumentException("Wrong argument.");
            }

            Brand = brand;
            Model = model;
            Amount = amount;
            Price = price;
        }
    }
}