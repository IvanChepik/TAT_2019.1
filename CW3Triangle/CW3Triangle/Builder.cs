using System;

namespace CW3Triangle
{
    /// <summary>
    /// Class Builder
    /// super class for all triangle builder, included next successor of chain of responbility and other common fields.
    /// </summary>
    public abstract class Builder
    {
        public Builder Successor { get; protected set; }

        /// <summary>
        /// Constructor Builder
        /// determines next successor.
        /// </summary>
        /// <param name="nextBuilder"></param>
        protected Builder(Builder nextBuilder)
        {
            Successor = nextBuilder;
        }

        public abstract Triangle BuilderRequest(Point x, Point y, Point z);

        /// <summary>
        /// Method CheckForTriangle
        /// Check for creating triangle by three points
        /// </summary>
        /// <param name="x">first point</param>
        /// <param name="y">second point</param>
        /// <param name="z">third point</param>
        protected void CheckForTriangle(Point x, Point y, Point z)
        {           
            if (Math.Abs((z.X - x.X) / (y.X - x.X) - ((z.Y - x.Y) / (y.Y - x.Y))) < 1E-15 || x.Equals(y) || y.Equals(z) || z.Equals(x))
            {
                throw new ArgumentException("It's not triangle");
            }
        }
    }
}