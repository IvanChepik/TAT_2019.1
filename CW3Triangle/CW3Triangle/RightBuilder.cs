using static  System.Math;

namespace CW3Triangle
{
    /// <summary>
    /// Class RightBuilder
    /// Check three points on right triangle, if yes create it, if no give the responbility next successor.
    /// </summary>
    public class RightBuilder : Builder
    {
        /// <summary>
        /// Constructor RightBuilder
        /// calls base constructor.
        /// </summary>
        /// <param name="nextBuilder"></param>
        public RightBuilder(Builder nextBuilder = null) : base(nextBuilder)
        {
        }

        /// <summary>
        /// Method BuilderRequest
        /// check three points on right and create new triangle or send data next successor.
        /// </summary>
        /// <param name="x">first point</param>
        /// <param name="y">second point</param>
        /// <param name="z">third point</param>
        /// <returns>triangle object</returns>
        public override Triangle BuilderRequest(Point x, Point y, Point z)
        {
            CheckForTriangle(x, y, z);
            return CheckOnRight(x,y,z) ? new RightTriangle(x,y,z) : Successor?.BuilderRequest(x, y, z);
        }

        /// <summary>
        /// Method CheckOnRight
        /// check three point on right triangle 
        /// </summary>
        /// <param name="x">First point</param>
        /// <param name="y">Second point</param>
        /// <param name="z">Third point</param>
        /// <returns>return true if triangle is right and false if else</returns>
        private bool CheckOnRight(Point x, Point y, Point z)
        {
            var xYLength = x.GetDistanceBetweenPoints(y);
            var yZLength = y.GetDistanceBetweenPoints(z);
            var zXLength = z.GetDistanceBetweenPoints(x);
            return Abs(xYLength * xYLength + yZLength * yZLength - zXLength * zXLength) < 1E-15 ||
                   Abs(yZLength * yZLength + zXLength * zXLength - xYLength * xYLength) < 1E-15 ||
                   Abs(xYLength * xYLength + zXLength * zXLength - yZLength * yZLength) < 1E-15;
        }
        
    }
}