namespace CW3Triangle
{
    /// <summary>
    /// Class SimpleBuilder
    /// Create simple triangle.
    /// </summary>
    public class SimpleBuilder : Builder
    {
        /// <summary>
        /// Constructor SimpleBuilder
        /// calls base constructor.
        /// </summary>
        /// <param name="nextBuilder"></param>
        public SimpleBuilder(Builder nextBuilder = null) : base(nextBuilder)
        {

        }

        /// <summary>
        /// Method BuilderRequest
        /// create new triangle.
        /// </summary>
        /// <param name="x">first point</param>
        /// <param name="y">second point</param>
        /// <param name="z">third point</param>
        /// <returns>triangle object</returns>
        public override Triangle BuilderRequest(Point x, Point y, Point z)
        {
            CheckForTriangle(x, y, z);
            return new SimpleTriangle(x, y, z);
        }        
    }
}