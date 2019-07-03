using System;
using  Points;

namespace Flying
{
    /// <summary>
    /// Interface IFlyable
    /// included common methods for flying object.
    /// </summary>
    public interface IFlyable
    {
        event Action<object, FlyingEventArgs> Flied;

        void FlyTo(Point newPoint);

        string WhoAmI();

        double GetFlyTime();
    }
}