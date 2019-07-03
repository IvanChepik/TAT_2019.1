using System;

namespace CW3Triangle
{
    /// <summary>
    /// Class EquilateralTriangle
    /// model of equilateral triangle.
    /// </summary>
    public class EquilateralTriangle : Triangle
    {
        /// <summary>
        /// Constructor EquilateralTriangle
        /// determines points of triangle
        /// </summary>
        /// <param name="x">first point</param>
        /// <param name="y">second point</param>
        /// <param name="z">third point</param>
        public EquilateralTriangle(Point x, Point y, Point z) : base(x, y, z)
        {
            
        }

        /// <summary>
        /// Method GetArea
        /// calculate and return area of triangle.
        /// </summary>
        /// <returns>area of triangle</returns>
        public override double GetArea()
        {
            var xYLength = X.GetDistanceBetweenPoints(Y);
            return Math.Sqrt(3) / 4 * Math.Pow(xYLength, 2);
        }
    }
}