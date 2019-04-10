using System;

namespace DEV_6
{
    public class Car
    {
        public string Brand { get;   }

        public string Model { get;  }

        public int Amount { get;  }

        public double Price { get; }

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