using System;

namespace DEV_6
{
    /// <summary>
    /// Class Printer
    /// included method Print which output message on console.
    /// </summary>
    public class Printer
    {
        /// <summary>
        /// Method Print
        /// Output message on console.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        public void Print(object sender, string message)
        {
            Console.WriteLine(message);
        }
    }
}