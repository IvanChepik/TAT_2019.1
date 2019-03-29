using Points;

namespace Flying
{
    public class Bird : IFlyable
    {
        public double FlyingTime { get; }

        public Point CurrentPoint { get; }

        public int Speed { get; }

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
            return "Bird";
        }
    }
}