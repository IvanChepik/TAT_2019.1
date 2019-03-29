using System;
using Points;

namespace DEV_5
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var point = new Point(0,0,0);
            Console.WriteLine(point.GetAbsoluteDistanceToPoint(1, 2, 3));
        }
    }
}
