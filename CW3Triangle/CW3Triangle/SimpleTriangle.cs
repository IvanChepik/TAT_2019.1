using System;

namespace CW3Triangle
{
    /// <summary>
    /// Class SimpleTriangle
    /// model of simple triangle.
    /// </summary>
    public class SimpleTriangle : Triangle
    {
        /// <summary>
        /// Constructor SimpleTriangle
        /// determines points of triangle
        /// </summary>
        /// <param name="x">first point</param>
        /// <param name="y">second point</param>
        /// <param name="z">third point</param>
        public SimpleTriangle(Point x, Point y, Point z) : base(x, y, z)
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
            var yZLength = Y.GetDistanceBetweenPoints(Z);
            var zXLength = Z.GetDistanceBetweenPoints(X);
            var halfPerimeter = (xYLength + zXLength + yZLength) / 2;

            return Math.Sqrt(halfPerimeter * (halfPerimeter - xYLength) * (halfPerimeter - yZLength) * (halfPerimeter - zXLength));
        }
    }
}