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
                if (!decimal.TryParse(Console.ReadLine(),out condition))
                {
                    throw new FormatException("Input number");
                }
                Company company = new Company(criterion, condition);
                company.Optimize();
                Console.WriteLine($"Juniors = {company.JuniorsOnProject}");
                Console.WriteLine($"Middles = {company.MiddlesOnProject}");
                Console.WriteLine($"Seniors = {company.SeniorsOnProject}");
                Console.WriteLine($"Leads = {company.LeadsOnProject}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error in command line : {ex.Message}!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error in inputing condition : {ex.Message}!");
            }
            catch (Exception)
            {
                Console.WriteLine("Something going wrong!");
            }
        }
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
    }
}
