using System;

namespace CW3Triangle
{
    /// <summary>
    /// Class EntryPoint
    /// definite the triangle and calculate area.
    /// </summary>
    public class EntryPoint
    {
        /// <summary>
        /// Method Main
        /// entry point.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            try
            {
                var xPoint = new Point(1,1);
                var yPoint = new Point(1, 2);
                var zPoint = new Point(3, 3);
                Builder mainBuilder = new RightBuilder(new EquilateralBuilder(new SimpleBuilder()));
                var triangle = mainBuilder.BuilderRequest(xPoint, yPoint, zPoint);
                Console.WriteLine(triangle.GetArea());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
