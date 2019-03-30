using System;
using Points;
using Flying;

namespace DEV_5
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            try
            {
                IFlyable bird = new SpaceShip(0, 0, 0);
                bird.Flied += DisplayFlyMessage;
                bird.FlyTo(new Point(200, 0, 0));
                Console.WriteLine(bird.GetFlyTime() + " hours");
            }
            catch (ObjectIDontFlyException e)
            {
                Console.WriteLine("Error : " + e.Message);
            }
        }

        private static void DisplayFlyMessage(object sender, FlyingEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Message);
        }
    }
}
