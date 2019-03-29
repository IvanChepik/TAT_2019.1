using Points;

namespace Flying
{
    public class SpaceShip : IFlyable
    {
        public double FlyingTime { get; }

        public Point CurrentPoint { get; }

        public int Speed { get; }

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
            throw new System.NotImplementedException();
        }

        public string WhoAmI()
        {
            return "SpaceShip";
        }

        public string GetFlyTime()
        {
            throw new System.NotImplementedException();
        }
    }
}