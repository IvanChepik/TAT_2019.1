using static System.Math;

namespace Points
{
    public struct Point
    {
        public int XCoordinate { get; }

        public int YCoordinate { get; }

        public int ZCoordinate { get; }

        public Point(int xCoordinate, int yCoordinate, int zCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            ZCoordinate = zCoordinate;
        }

        public double GetAbsoluteDistanceToPoint(Point targetPoint)
        {
            return Sqrt(Pow(targetPoint.XCoordinate - XCoordinate, 2) + Pow(targetPoint.YCoordinate - YCoordinate, 2) +
                        Pow(targetPoint.ZCoordinate - ZCoordinate, 2));
        }

        public double GetAbsoluteDistanceToPoint(int xCoordinate, int yCoordinate, int zCoordinate)
        {
            return Sqrt(Pow(xCoordinate - XCoordinate, 2) + Pow(yCoordinate - YCoordinate, 2) +
                        Pow(zCoordinate - ZCoordinate, 2));
        }
    }
}
