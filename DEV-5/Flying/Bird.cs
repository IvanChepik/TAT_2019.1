using System;
using Points;

namespace Flying
{
    public class Bird : IFlyable
    {
        public Point CurrentPoint { get; }

        public double Speed { get; private set; }

        public bool Flied { get; private set; }

        public Point TargetPoint { get; private set; }

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
            TargetPoint = newPoint;
            Flied = true;
        }

        public double GetFlyTime()
        {
            return CurrentPoint.GetAbsoluteDistanceToPoint(TargetPoint) / Speed;
        }

        public string WhoAmI()
        {
            return "Bird";
        }
    }
}