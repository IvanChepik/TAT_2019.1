using System;
using Points;

namespace Flying
{
    /// <summary>
    /// Class Plane
    /// it's a plane's model of real life which implement interface IFlyable
    /// </summary>
    public class Plane : IFlyable
    {
        public double TempOfAcceleration { get; private set; }

        public event Action<object, FlyingEventArgs> Flied;

        public double Acceleration { get; private set; }

        public Point CurrentPoint { get; }

        public double Speed { get; private set; }

        public bool InFly { get; private set; }

        public Point TargetPoint { get; private set; }

        /// <summary>
        /// Constructor Plane
        /// determines the initial position of the object by Point struct.
        /// </summary>
        /// <param name="point">initial point of object</param>
        public Plane(Point point)
        {
            CurrentPoint = point;
        }

        /// <summary>
        /// Constructor Plane
        /// determines the initial position of the object by three coordinates.
        /// </summary>
        /// <param name="xCoordinate">x coordinate of position</param>
        /// <param name="yCoordinate">y coordinate of position</param>
        /// <param name="zCoordinate">z coordinate of position</param>
        public Plane(int xCoordinate, int yCoordinate, int zCoordinate)
        {
            CurrentPoint = new Point(xCoordinate, yCoordinate, zCoordinate);
        }

        /// <summary>
        /// Method OnFlied
        /// checks Flied event for null and calls it.
        /// </summary>
        private void OnFlied()
        {
            Flied?.Invoke(this, new FlyingEventArgs(WhoAmI() + " fly to new point"));
        }

        /// <summary>
        /// Method FlyTo
        /// sets a object speed, acceleration and new target point and InFly field.
        /// </summary>
        /// <param name="newPoint"></param>
        public void FlyTo(Point newPoint)
        {
            TargetPoint = newPoint;
            Speed = 200;
            TempOfAcceleration = 10;
            Acceleration = 10;
            InFly = true;
            OnFlied();
        }

        /// <summary>
        /// Method GetFlyTime
        /// calculates the time object will reach target point
        /// </summary>
        /// <returns>time object will reach target point in hours</returns>
        public double GetFlyTime()
        {
            return InFly ? CurrentPoint.GetAbsoluteDistanceToPoint(TargetPoint) / (GetSpeedAtTargetPoint() + Speed)
                 : throw new ObjectIDontFlyException("Plane doesn't in flight");
        }

        /// <summary>
        /// Method GetSpeedAtTargetPoint
        /// calculates the speed of object at target point
        /// </summary>
        /// <returns>speed of object at target point</returns>
        private double GetSpeedAtTargetPoint()
        {
            return (CurrentPoint.GetAbsoluteDistanceToPoint(TargetPoint) / TempOfAcceleration) * Acceleration;
        }

        /// <summary>
        /// Method WhoAmI
        /// return the name of object
        /// </summary>
        /// <returns>name of object as string</returns>
        public string WhoAmI()
        {
            return "Plane";
        }
    }
}