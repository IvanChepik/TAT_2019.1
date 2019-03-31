using System;
using System.Collections.Generic;
using Points;
using Flying;

namespace DEV_5
{
    /// <summary>
    /// Class EntryPoint
    /// gets fly time for 3 object of this classes.
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
                var startPoint = new Point(0, 0, 0);
                var newPoint = new Point(100,200,800);
                var flyables = new List<IFlyable>
                {
                    new Bird(startPoint),
                    new Plane(startPoint),
                    new SpaceShip(startPoint)
                };
                foreach (var flyable in flyables)
                {
                    flyable.Flied += DisplayFlyMessage;
                    flyable.FlyTo(newPoint);
                    Console.WriteLine(flyable.GetFlyTime());
                }
                
            }
            catch (ObjectIDontFlyException e)
            {
                Console.WriteLine("Error : " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something going wrong : " + e.Message );
            }
        }

        /// <summary>
        /// Method DisplayFlyMessage
        /// handler for Flied event, calls when object in flight.
        /// </summary>
        /// <param name="sender">object calls event</param>
        /// <param name="eventArgs">arguments for events</param>
        private static void DisplayFlyMessage(object sender, FlyingEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Message);
        }
    }
}
