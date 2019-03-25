using System;
using Criterions;

namespace DEV_3
{
    /// <summary>
    /// Class EntryPoint
    /// Receives a int number (1,2,3), which match with different criterion
    /// </summary>
    public class EntryPoint
    {/// <summary>
     /// Method Main
     /// Entry point
     /// </summary>
     /// <param name="args">Arguments from the command line.
     /// 1 is Criterion of Max Productivity with fix cost
     /// 2 is Criterion of Min Cost with fix productivity
     /// 3 is Criterion of Employees without Juniors</param>
        public static void Main(string[] args)
        {
            int choosingCriterion;
            decimal condition;
            try
            {
                IOptimize criterion;

                if (int.TryParse(args[0], out choosingCriterion))
                {
                    if(!TryParseCriterion(choosingCriterion, out criterion))
                    {
                        throw new ArgumentException($"Wrong criterion choosing. There is no {choosingCriterion} criterion");
                    }
                }
                else
                {
                    throw new ArgumentException("Wrong format argument. Input int number");
                }

                Console.WriteLine("Input a value of conidion");

                if (!decimal.TryParse(Console.ReadLine(),out condition))
                {
                    throw new FormatException("Input number");
                }

                Company company = new Company(criterion, condition);
                company.Optimize();
                DisplayEmployeesOnProject(company);
                
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error in command line : {ex.Message}!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error in inputing condition : {ex.Message}!");
            }
            catch (WorkCannotBeExecutedException ex)
            {
                Console.WriteLine($"Error with workness: {ex.Message}!");
            }
            catch (Exception)
            {
                Console.WriteLine("Something going wrong!");
            }
        }

        /// <summary>
        /// method TryParseCriterion
        /// select type of object which will in ref criterion by argument choosingCriterion
        /// </summary>
        /// <param name="choosingCriterion">number which select type of criterion </param>
        /// <param name="criterion">ref on criterion which was selected in this method</param>
        /// <returns>return true if parsing is correct or false if is not correct</returns>
        private static bool TryParseCriterion(int choosingCriterion, out IOptimize criterion)
        {
            if (choosingCriterion == (int)Criterions.CriterionMaxProduct)
            {              
                criterion = new CriterionMaxProduct();
                return true;
            }

            if (choosingCriterion == (int)Criterions.CriterionMinCost)
            {
                criterion = new CriterionMinCoast();
                return true;
            }

            if (choosingCriterion == (int)Criterions.CriterionNoJunior)
            {
                criterion = new CriterionNoJunior();
                return true;
            }

            criterion = null;
            return false;
        }

        /// <summary>
        /// method DisplayEmployeesOnProject
        /// displays quantity employees of every type
        /// </summary>
        /// <param name="company">company with list of employees on project</param>
        private static void DisplayEmployeesOnProject(Company company)
        {
            Console.WriteLine($"Juniors = {company.JuniorsOnProject}");
            Console.WriteLine($"Middles = {company.MiddlesOnProject}");
            Console.WriteLine($"Seniors = {company.SeniorsOnProject}");
            Console.WriteLine($"Leads = {company.LeadsOnProject}");
        }

    }
}
