using static System.Math;

namespace CW3Triangle
{
    /// <summary>
    /// Struct Point
    /// includes two coordinate of point and method GetDistanceBetweenPoints.
    /// </summary>
    public struct Point
    {
        public double X { get; }

        public double Y { get; }

        /// <summary>
        /// Constructor Point
        /// determines two coordinate of point.
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Method GetDistanceBetweenPoints
        /// return absolute distance to target point.
        /// </summary>
        /// <param name="targetPoint">target point</param>
        /// <returns>distance to target point</returns>
        public double GetDistanceBetweenPoints(Point targetPoint)
        {
            return Abs(Sqrt(Pow(X - targetPoint.X, 2) + Pow(Y - targetPoint.Y, 2)));
        }

        /// <summary>
        /// Method Equals
        /// equals two points by coordinate.
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>true if equaled false if not</returns>
        public override bool Equals(object obj)
        {
            return obj is Point comparePoint && ((Abs(X - comparePoint.X) < 10E-15) && (Abs(Y - comparePoint.Y) < 10E-15));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }
    }
}