using  Points;

namespace Flying
{
    public interface IFlyable
    {
        void FlyTo(Point newPoint);

        string WhoAmI();

        string GetFlyTime();
    }
}