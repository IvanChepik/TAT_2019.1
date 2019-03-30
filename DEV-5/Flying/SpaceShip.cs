using System;
using Points;

namespace Flying
{
    public class SpaceShip : IFlyable
    {
        public Point CurrentPoint { get; }

        public event Action<object, FlyingEventArgs> Flied;

        public double Speed { get; private set; }

        public bool InFly { get; private set; }

        public Point TargetPoint { get; private set; }

        public SpaceShip(Point point)
        {
            CurrentPoint = point;
        }

        public SpaceShip(int xCoordinate, int yCoordinate, int zCoordinate)
        {
            CurrentPoint = new Point(xCoordinate, yCoordinate, zCoordinate);
        }

        private void OnFlied()
        {
            Flied?.Invoke(this, new FlyingEventArgs(WhoAmI() + " fly to new point"));
        }

        public void FlyTo(Point newPoint)
        {            
            Speed = 2.88 * Math.Pow(10, 7);
            TargetPoint = newPoint;
            InFly = true;
            OnFlied();
        }

        public string WhoAmI()
        {
            return "SpaceShip";
        }

        public double GetFlyTime()
        {
            return InFly ? CurrentPoint.GetAbsoluteDistanceToPoint(TargetPoint) / Speed
                : throw new ObjectIDontFlyException("SpaceShip doesn't in flight");
        }
    }
}