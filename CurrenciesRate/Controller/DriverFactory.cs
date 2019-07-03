using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Controller
{
    /// <summary>
    /// Class DriverFactory
    /// create new Driver
    /// </summary>
    public class DriverFactory
    {
        /// <summary>
        /// Method CreateDriver
        /// create and return new driver by drivername
        /// </summary>
        /// <param name="driverName"></param>
        /// <returns></returns>
        public IWebDriver CreateDriver(string driverName)
        {
            switch (GetDriverType(driverName))
            {
                case DriverType.Firefox:
                    return new FirefoxDriver();
                default: throw new ArgumentException("Wrong driver type");
            }
        }

        private DriverType GetDriverType(string driverName)
        {
            if (driverName.Equals("Firefox"))
            {
                return DriverType.Firefox;
            }

            throw new ArgumentException("Wrong driver name");
        }
    }
}