using System;
using Points;

namespace Flying
{
    public class SpaceShip : IFlyable
    {
        public Point CurrentPoint { get; }

        public double Speed { get; private set; }

        public bool Flied { get; private set; }

        public Point TargetPoint { get; private set; }

        public SpaceShip(Point point)
        {
            CurrentPoint = point;
        }

        public SpaceShip(int xCoordinate, int yCoordinate, int zCoordinate)
        {
            CurrentPoint = new Point(xCoordinate, yCoordinate, zCoordinate);
        }

        public void FlyTo(Point newPoint)
        {
            Speed = 2.88 * Math.Pow(10, 7);
            TargetPoint = newPoint;
            Flied = true;
        }

        public string WhoAmI()
        {
            return "SpaceShip";
        }

        public double GetFlyTime()
        {
            return CurrentPoint.GetAbsoluteDistanceToPoint(TargetPoint) / Speed;
        }
    }
}