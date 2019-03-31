using static System.Math;

namespace Points
{
    /// <summary>
    /// Struct Point
    /// included the coordinate, determines the location.
    /// </summary>
    public struct Point
    {
        public int XCoordinate { get; }

        public int YCoordinate { get; }

        public int ZCoordinate { get; }

        /// <summary>
        /// Struct Point
        /// Initializes the location by coordinates.
        /// </summary>
        /// <param name="xCoordinate">x coordinate</param>
        /// <param name="yCoordinate">y coordinate</param>
        /// <param name="zCoordinate">z coordinate</param>
        public Point(int xCoordinate, int yCoordinate, int zCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            ZCoordinate = zCoordinate;
        }

        /// <summary>
        /// Method GetAbsoluteDistanceToPoint
        /// determines the distance to another point.
        /// </summary>
        /// <param name="targetPoint">target point</param>
        /// <returns>distance to target point</returns>
        public double GetAbsoluteDistanceToPoint(Point targetPoint)
        {
            return Sqrt(Pow(targetPoint.XCoordinate - XCoordinate, 2) + Pow(targetPoint.YCoordinate - YCoordinate, 2) +
                        Pow(targetPoint.ZCoordinate - ZCoordinate, 2));
        }

        /// <summary>
        /// Method GetAbsoluteDistanceToPoint
        /// determines the distance to another point by coordinate
        /// </summary>
        /// <param name="xCoordinate">x coordinate</param>
        /// <param name="yCoordinate">y coordinate</param>
        /// <param name="zCoordinate">z coordinate</param>
        /// <returns>distance to target point</returns>
        public double GetAbsoluteDistanceToPoint(int xCoordinate, int yCoordinate, int zCoordinate)
        {
            return Sqrt(Pow(xCoordinate - XCoordinate, 2) + Pow(yCoordinate - YCoordinate, 2) +
                        Pow(zCoordinate - ZCoordinate, 2));
        }
    }
}
