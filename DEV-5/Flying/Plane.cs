using Points;

namespace Flying
{
    public class Plane : IFlyable
    {
        public double FlyingTime { get; }

        public Point CurrentPoint { get; }

        public int Speed { get; }

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
            throw new System.NotImplementedException();
        }

        public string GetFlyTime()
        {
            throw new System.NotImplementedException();
        }

        public string WhoAmI()
        {
            return "Plane";
        }
    }
}