using System;
using  Points;

namespace Flying
{
    public interface IFlyable
    {
        bool Flied { get; }

        double FlyingTime { get; } 

        Point CurrentPoint { get; }

        int Speed { get; }

        void FlyTo(Point newPoint);

        string WhoAmI();

        string GetFlyTime();
    }
}