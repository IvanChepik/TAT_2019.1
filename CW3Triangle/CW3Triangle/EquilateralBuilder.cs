using System;

namespace CW3Triangle
{
    /// <summary>
    /// Class EquilateralBuilder
    /// Check three points on equilateral triangle, if yes create it, if no give the responbility next successor.
    /// </summary>
    public class EquilateralBuilder : Builder 
    {
        /// <summary>
        /// Constructor EquilateralBuilder
        /// calls base constructor.
        /// </summary>
        /// <param name="nextBuilder"></param>
        public EquilateralBuilder(Builder nextBuilder = null) : base(nextBuilder)
        {

        }

        /// <summary>
        /// Method BuilderRequest
        /// check three points on equilateral and create new triangle or send data next successor.
        /// </summary>
        /// <param name="x">first point</param>
        /// <param name="y">second point</param>
        /// <param name="z">third point</param>
        /// <returns>triangle object</returns>
        public override Triangle BuilderRequest(Point x, Point y, Point z)
        {
            CheckForTriangle(x, y, z);
            return CheckOnEquilateral(x,y,z) ? new EquilateralTriangle(x, y, z) : Successor?.BuilderRequest(x,y,z);
        }

        /// <summary>
        /// Method CheckOnEquilateral
        /// check three point on equilateral triangle 
        /// </summary>
        /// <param name="x">First point</param>
        /// <param name="y">Second point</param>
        /// <param name="z">Third point</param>
        /// <returns>return true if triangle is equilateral and false if else</returns>
        private bool CheckOnEquilateral(Point x, Point y, Point z)
        {
            return Math.Abs(x.GetDistanceBetweenPoints(y) - y.GetDistanceBetweenPoints(z)) < 10E-15 && Math.Abs(y.GetDistanceBetweenPoints(z) - z.GetDistanceBetweenPoints(x)) < 10E-15;
        }
    }
}