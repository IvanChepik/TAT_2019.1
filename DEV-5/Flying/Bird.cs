using System;
using Points;

namespace Flying
{
    public class Bird : IFlyable
    {
        public double FlyingTime { get; }

        public Point CurrentPoint { get; }

        public int Speed { get; private set; }

        public bool Flied => throw new NotImplementedException();

        public Bird(Point point)
        {
            CurrentPoint = point;
        }

        public Bird(int xCoordinate, int yCoordinate, int zCoordinate)
        {
            CurrentPoint = new Point(xCoordinate, yCoordinate, zCoordinate);
        }

        public void FlyTo(Point newPoint)
        {
            Speed = new Random().Next(1, 20);
            
        }

        public string GetFlyTime()
        {
            throw new System.NotImplementedException();
        }

        public string WhoAmI()
        {
            return "Bird";
        }
    }
}