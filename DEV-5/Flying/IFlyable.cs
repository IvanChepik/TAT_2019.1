using  Points;

namespace Flying
{
    public interface IFlyable
    {
        bool Flied { get; }

        Point TargetPoint { get; }

        Point CurrentPoint { get; }

        double Speed { get; }

        void FlyTo(Point newPoint);

        string WhoAmI();

        double GetFlyTime();
    }
}