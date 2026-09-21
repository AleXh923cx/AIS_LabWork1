using System;
using Model;

namespace View_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();

            Console.WriteLine("|      Name      |  Age  |");
            Console.WriteLine("|----------------|-------|");
            foreach (var chrcter in logic.GetAllCharacters())
            {
                Console.WriteLine($"| {chrcter.Name} \t | {chrcter.Age} \t |");
            }

            Console.ReadLine();
        }
    }
}