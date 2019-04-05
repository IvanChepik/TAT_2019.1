using System;

namespace CW3Triangle
{
    /// <summary>
    /// Class RightTriangle
    /// model of right triangle.
    /// </summary>
    public class RightTriangle : Triangle
    {
        /// <summary>
        /// Constructor RightTriangle
        /// determines points of triangle
        /// </summary>
        /// <param name="x">first point</param>
        /// <param name="y">second point</param>
        /// <param name="z">third point</param>
        public RightTriangle(Point x, Point y, Point z) : base(x, y, z)
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
            var hypotenuse = Math.Max(xYLength, Math.Max(yZLength, zXLength));

            if (Math.Abs(xYLength - hypotenuse) < 10E-15)
            {
                return yZLength * zXLength * 1 / 2;
            }

            if (Math.Abs(yZLength - hypotenuse) < 10E-15)
            {
                return zXLength * xYLength * 1 / 2;
            }

            if (Math.Abs(zXLength -  hypotenuse) < 10E-15)
            {
                return yZLength * xYLength * 1 / 2;
            }

            throw new ArgumentException("Triangle is not exist");
        }
    }
}