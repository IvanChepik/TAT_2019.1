using Points;

namespace Flying
{
    public class Plane : IFlyable
    {
        public double TempOfAcceleration { get; private set; } 

        public double Acceleration { get; private set; }

        public Point CurrentPoint { get; }

        public double Speed { get; private set; }

        public bool Flied { get; private set; }

        public Point TargetPoint { get; private set; }

        public Plane(Point point)
        {
            CurrentPoint = point;
        }

        public Plane(int xCoordinate, int yCoordinate, int zCoordinate)
        {
            CurrentPoint = new Point(xCoordinate, yCoordinate, zCoordinate);
        }

        public void FlyTo(Point newPoint)
        {
            TargetPoint = newPoint;
            Speed = 200;
            Flied = true;
        }

        public double GetFlyTime()
        {
           return CurrentPoint.GetAbsoluteDistanceToPoint(TargetPoint) / (GetSpeedAtTargetPoint() + Speed);
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