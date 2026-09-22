using System;
using Model;

namespace View_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();

            Console.WriteLine("| №  |       Name        |     Genus     |  Age  |");
            Console.WriteLine("|----|-------------------|---------------|-------|");
            foreach (var chrcter in logic.GetAllCharacters())
            {
                Console.WriteLine($"| {chrcter.Id,2} | {chrcter.Name,10} \t | {chrcter.Genus,8} \t | {chrcter.Age,2} \t |");
            }

            Console.ReadLine();
        }
    }
}