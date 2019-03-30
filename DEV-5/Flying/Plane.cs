using System;
using Points;

namespace Flying
{
    public class Plane : IFlyable
    {
        public double TempOfAcceleration { get; private set; }

        public event Action<object, FlyingEventArgs> Flied;

        public double Acceleration { get; private set; }

        public Point CurrentPoint { get; }

        public double Speed { get; private set; }

        public bool InFly { get; private set; }

        public Point TargetPoint { get; private set; }

        public Plane(Point point)
        {
            CurrentPoint = point;
        }

        public Plane(int xCoordinate, int yCoordinate, int zCoordinate)
        {
            CurrentPoint = new Point(xCoordinate, yCoordinate, zCoordinate);
        }

        private void OnFlied()
        {
            Flied?.Invoke(this, new FlyingEventArgs(WhoAmI() + " fly to new point"));
        }

        public void FlyTo(Point newPoint)
        {
            TargetPoint = newPoint;
            Speed = 200;
            TempOfAcceleration = 10;
            Acceleration = 10;
            InFly = true;
            OnFlied();
        }

        public double GetFlyTime()
        {
            return InFly ? CurrentPoint.GetAbsoluteDistanceToPoint(TargetPoint) / (GetSpeedAtTargetPoint() + Speed)
                 : throw new ObjectIDontFlyException("Plane doesn't in flight");
        }

        private double GetSpeedAtTargetPoint()
        {
            return (CurrentPoint.GetAbsoluteDistanceToPoint(TargetPoint) / TempOfAcceleration) * Acceleration;
        }

        public string WhoAmI()
        {
            return "Plane";
        }
    }
}