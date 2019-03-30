using System;
using Points;

namespace Flying
{
    public class Bird : IFlyable
    {
        public Point CurrentPoint { get; }

        public event Action<object, FlyingEventArgs> Flied;

        public double Speed { get; private set; }

        public bool InFly { get; private set; }

        public Point TargetPoint { get; private set; }

        public Bird(Point point)
        {
            CurrentPoint = point;
        }

        public Bird(int xCoordinate, int yCoordinate, int zCoordinate)
        {
            CurrentPoint = new Point(xCoordinate, yCoordinate, zCoordinate);
        }

        private void OnFlied()
        {
            Flied?.Invoke(this, new FlyingEventArgs(WhoAmI() + " fly to new point"));
        }

        public void FlyTo(Point newPoint)
        {
            Speed = new Random().Next(1, 20);
            TargetPoint = newPoint;
            InFly = true;
            OnFlied();
        }

        public double GetFlyTime()
        {
            return InFly ? CurrentPoint.GetAbsoluteDistanceToPoint(TargetPoint) / Speed
                : throw new ObjectIDontFlyException("Bird doesn't in flight");
        }

        public string WhoAmI()
        {
            return "Bird";
        }
    }
}