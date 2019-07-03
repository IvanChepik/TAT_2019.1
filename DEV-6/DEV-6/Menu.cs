using System;

namespace DEV_6
{
    /// <summary>
    /// Class Menu
    /// create menu for our program and invoke the commands.
    /// </summary>
    public class Menu
    {
        private CarCatalog _carCatalog;

        private Printer _printer;

        private bool _alive = true;

        /// <summary>
        /// Constructor Menu
        /// create printer object and set carCatalog for our application
        /// </summary>
        /// <param name="carCatalog"></param>
        public Menu(CarCatalog carCatalog)
        {
            _printer = new Printer();
            _carCatalog = carCatalog;
        }

        /// <summary>
        /// Method Show
        /// show our commands and allow to input them.
        /// </summary>
        public void Show()
        {
            Console.WriteLine("Enter command:\n" +
                              "1.count_types_car\n" +
                              "2.count_all_car\n" +
                              "3.average_price_car\n" +
                              "4.average_price_car type\n" +
                              "5.exit\n");

            Commands command;

            while (_alive)
            {
                var inputString = Console.ReadLine()?.Split(' ');
                command = GetCommand(inputString);

                try
                {
                    switch (command)
                    {
                        case Commands.AveragePriceAll:
                            var averagePriceAllCommand = new AveragePriceAll(_carCatalog);
                            averagePriceAllCommand.Requested += _printer.Print;
                            averagePriceAllCommand.Execute();
                            break;
                        case Commands.AveragePriceType:
                            var averagePriceTypeCommand = new AveragePriceType(_carCatalog, inputString[1]);
                            averagePriceTypeCommand.Requested += _printer.Print;
                            averagePriceTypeCommand.Execute();
                            break;
                        case Commands.CountAll:
                            var countAllCommand = new CountAll(_carCatalog);
                            countAllCommand.Requested += _printer.Print;
                            countAllCommand.Execute();
                            break;
                        case Commands.CountTypes:
                            var countTypes = new CountTypes(_carCatalog);
                            countTypes.Requested += _printer.Print;
                            countTypes.Execute();
                            break;
                        case Commands.Exit:
                            _alive = false;
                            break;
                        case Commands.NoCommands:
                            _printer.Print(this, "Wrong command!!!");
                            break;
                    }
                }
                catch (NoTypeCarException e)
                {
                    _printer.Print(this,e.Message);
                }
            }
        }

        /// <summary>
        /// Method GetCommand
        /// choose the returning enum by inputed string.
        /// </summary>
        /// <param name="str">string which was inputed by user</param>
        /// <returns>Enum of available сommands</returns>
        private Commands GetCommand(string[] str)
        {
            if (str[0].ToLower().Equals("count_all_car"))
            {
                return Commands.CountAll;
            }
            else if (str[0].ToLower().Equals("count_types_car"))
            {
                return Commands.CountTypes;
            }
            else if (str[0].ToLower().Equals("average_price_car") && str.Length == 2)
            {
                return Commands.AveragePriceType;
            }
            else if (str[0].ToLower().Equals("average_price_car"))
            {
                return Commands.AveragePriceAll;
            }
            else if (str[0].ToLower().Equals("exit"))
            {
                return Commands.Exit;
            }
            else
            {
                return Commands.NoCommands;
            }
        }
    }
}