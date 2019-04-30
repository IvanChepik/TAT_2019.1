using System;
using System.Collections.Generic;

namespace DEV_6
{
    /// <summary>
    /// Class Menu
    /// create menu for our program and invoke the commands.
    /// </summary>
    public class Menu
    {
        private readonly VehiclesCatalog _carCatalog;

        private readonly VehiclesCatalog _truckCatalog;

        private Printer _printer;

        private bool _executed;

        /// <summary>
        /// Constructor Menu
        /// create printer object and set carCatalog for our application
        /// </summary>
        /// <param name="carCatalog">Catalog of our cars</param>
        /// <param name="truckCatalog">Catalog of our trucks</param>
        public Menu(VehiclesCatalog carCatalog, VehiclesCatalog truckCatalog)
        {
            this._printer = new Printer();
            this._truckCatalog = truckCatalog;
            this._carCatalog = carCatalog;
        }

        /// <summary>
        /// Method Show
        /// show our commands and allow to input them.
        /// </summary>
        public void Show()
        {
            Console.WriteLine("Enter command:\n" +
                              "1.count_types truck(car)\n" +
                              "2.count_all truck(car)\n" +
                              "3.average_price truck(car)\n" +
                              "4.average_price truck(car) type\n" +
                              "5.execute\n");

            Commands command;
            VehiclesCatalog choosenCatalog = null;
            var commandsList = new List<ICommand>();
            while (!this._executed)
            {
                var inputString = Console.ReadLine()?.Split(' ');
                command = this.GetCommand(inputString);
                try
                {
                    if ((command != Commands.NoCommands) && command != Commands.Execute)
                    {
                        choosenCatalog = this.GetCatalogType(inputString[1]);
                    }

                    switch (command)
                    {
                        case Commands.AveragePriceAll:
                            var averagePriceAllCommand = new AveragePriceAll(choosenCatalog);
                            averagePriceAllCommand.Requested += this._printer.Print;
                            commandsList.Add(averagePriceAllCommand);
                            break;
                        case Commands.AveragePriceType:
                            var averagePriceTypeCommand = new AveragePriceType(choosenCatalog, inputString[2]);
                            averagePriceTypeCommand.Requested += this._printer.Print;
                            commandsList.Add(averagePriceTypeCommand);
                            break;
                        case Commands.CountAll:
                            var countAllCommand = new CountAll(choosenCatalog);
                            countAllCommand.Requested += this._printer.Print;
                            commandsList.Add(countAllCommand);
                            break;
                        case Commands.CountTypes:
                            var countTypesCommand = new CountTypes(choosenCatalog);
                            countTypesCommand.Requested += this._printer.Print;
                            commandsList.Add(countTypesCommand);
                            break;
                        case Commands.Execute:
                            this._executed = true;
                            foreach (var commandExecuting in commandsList)
                            {
                                commandExecuting.Execute();
                            }
                            break;
                        case Commands.NoCommands:
                            _printer.Print(this, "Wrong command!!!");
                            break;
                    }                   
                }
                catch (NoTypeCarException e)
                {
                    this._printer.Print(this, e.Message);
                }
                catch (Exception)
                {
                    this._printer.Print(this, "Problem with XML file");
                }
            }
        }

        /// <summary>
        /// Method GetCommand
        /// choose the returning enum by inputed string.
        /// </summary>
        /// <param name="selectedCommand">string which was inputed by user</param>
        /// <returns>Enum of available сommands</returns>
        private Commands GetCommand(string[] selectedCommand)
        {
            if (selectedCommand[0].ToLower().Equals("count_all"))
            {
                return Commands.CountAll;
            }
            else if (selectedCommand[0].ToLower().Equals("count_types"))
            {
                return Commands.CountTypes;
            }
            else if (selectedCommand[0].ToLower().Equals("average_price") && selectedCommand.Length == 3)
            {
                return Commands.AveragePriceType;
            }
            else if (selectedCommand[0].ToLower().Equals("average_price"))
            {
                return Commands.AveragePriceAll;
            }
            else if (selectedCommand[0].ToLower().Equals("execute"))
            {
                return Commands.Execute;
            }
            else
            {
                return Commands.NoCommands;
            }
        }

        /// <summary>
        /// Method GetCatalogType
        /// determines the type of catalog.
        /// </summary>
        /// <param name="selectedType">command, determines type of catalog</param>
        /// <returns>catalog of cars/trucks</returns>
        private VehiclesCatalog GetCatalogType(string selectedType)
        {
            switch (this.GetVehicleType(selectedType))
            {
                case VehicleTypes.Truck:
                    return this._truckCatalog;
                case VehicleTypes.Car:
                    return this._carCatalog;
                default:
                    throw new NoTypeCarException("Wrong type of vehicle");
            }
        }

        /// <summary>
        /// Method GetVehicleType
        /// determines the enum of catalog by string.
        /// </summary>
        /// <param name="selectedType">command, determines enum</param>
        /// <returns>enum of catalog</returns>
        private VehicleTypes GetVehicleType(string selectedType)
        {
            try
            {
                selectedType = char.ToUpper(selectedType[0]) + selectedType.Substring(1).ToLower();
                return (VehicleTypes)(Enum.Parse(typeof(VehicleTypes), selectedType));
            }
            catch 
            {
                throw new NoTypeCarException("Wrong type of vehicle");
            }           
        }
    }
}