using System;
using  Points;

namespace Flying
{
    public interface IFlyable
    {
        bool InFly { get; }

        Point TargetPoint { get; }

        Point CurrentPoint { get; }

        event Action<object, FlyingEventArgs> Flied;

        double Speed { get; }

        void FlyTo(Point newPoint);

        string WhoAmI();

        double GetFlyTime();
    }
}