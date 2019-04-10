using System;

namespace DEV_6
{
    public class Menu
    {
        private CarCatalog _carCatalog;

        private bool _alive = true;

        public Menu(CarCatalog carCatalog)
        {
            _carCatalog = carCatalog;
        }

        public void Show()
        {
            Console.WriteLine("Enter command:\n" +
                              "1.count_types_car\n" +
                              "2.count_all_car\n" +
                              "3.average_price_car\n" +
                              "4.average_price_car type\n" +
                              "5.exit\n");

            Commands command;

            ICommand executedCommand = null;

            while (_alive)
            {
                var inputString = Console.ReadLine()?.Split(' ');
                command = GetCommand(inputString);

                switch (command)
                {
                    case Commands.AveragePriceAll: 
                        executedCommand = new AveragePriceAll(_carCatalog);
                        break;
                    case Commands.AveragePriceType:
                        executedCommand = new AveragePriceType(_carCatalog, inputString[1]);
                        break;
                    case Commands.CountAll:
                        executedCommand = new CountAll();
                        break;
                    case Commands.CountTypes:
                        executedCommand = new CountTypes();
                        break;
                    case Commands.Exit:
                        _alive = false;
                        break;
                    case Commands.NoCommands:
                        Console.WriteLine("Input wrong command!!!");
                        break;
                    
                }

                executedCommand?.Execute();
            }
        }

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