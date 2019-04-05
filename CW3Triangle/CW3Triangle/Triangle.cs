namespace CW3Triangle
{
    /// <summary>
    /// Class Triangle
    /// included common fields and methods for all triangles.
    /// </summary>
    public abstract class Triangle
    {
        public Point X { get; }

        public Point Y { get; }

        public Point Z { get; }

        /// <summary>
        /// Constructor Triangle
        /// determines points of triangle.
        /// </summary>
        /// <param name="x">fist point</param>
        /// <param name="y">second point</param>
        /// <param name="z">third point</param>
        protected Triangle(Point x, Point y, Point z)
        {
            X = x;

            Y = y;

            Z = z;
        }

        public abstract double GetArea();
    }
}