﻿using System;
using Points;

namespace Flying
{
    /// <summary>
    /// Class SpaceShip
    /// it's a bird's model of real life which implement interface IFlyable.
    /// </summary>
    public class SpaceShip : IFlyable
    {
        public Point CurrentPoint { get; }

        public event Action<object, FlyingEventArgs> Flied;

        public double Speed { get; private set; }

        public bool InFly { get; private set; }

        public Point TargetPoint { get; private set; }

        /// <summary>
        /// Constructor SpaceShip
        /// determines the initial position of the object by Point struct.
        /// </summary>
        /// <param name="point">initial point of object</param>
        public SpaceShip(Point point)
        {
            CurrentPoint = point;
        }

        /// <summary>
        /// Constructor SpaceShip
        /// determines the initial position of the object by three coordinates.
        /// </summary>
        /// <param name="xCoordinate">x coordinate of position</param>
        /// <param name="yCoordinate">y coordinate of position</param>
        /// <param name="zCoordinate">z coordinate of position</param>
        public SpaceShip(int xCoordinate, int yCoordinate, int zCoordinate)
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
        /// sets a object speed and new target point and InFly field.
        /// </summary>
        /// <param name="newPoint"></param>
        public void FlyTo(Point newPoint)
        {            
            Speed = 2.88 * Math.Pow(10, 7);
            TargetPoint = newPoint;
            InFly = true;
            OnFlied();
        }

        /// <summary>
        /// Method WhoAmI
        /// return the name of object
        /// </summary>
        /// <returns>name of object as string</returns>
        public string WhoAmI()
        {
            return "SpaceShip";
        }

        /// <summary>
        /// Method GetFlyTime
        /// calculates the time object will reach target point
        /// </summary>
        /// <returns>time object will reach target point in hours</returns>
        public double GetFlyTime()
        {
            return InFly ? CurrentPoint.GetAbsoluteDistanceToPoint(TargetPoint) / Speed
                : throw new ObjectIDontFlyException("SpaceShip doesn't in flight");
        }
    }
}