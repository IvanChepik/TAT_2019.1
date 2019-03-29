using  Points;

namespace Flying
{
    public interface IFlyable
    {
        double FlyingTime { get; } 

        Point CurrentPoint { get; }

        int Speed { get; }

        void FlyTo(Point newPoint);

        string WhoAmI();

        string GetFlyTime();
    }
}