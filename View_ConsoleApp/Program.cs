using System;
using Model;

namespace View_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();

            Console.WriteLine("| №  |    Имя     |   Вид    | Возраст | Уровень |");
            Console.WriteLine("|----|------------|----------|---------|---------|");
            foreach (var chrcter in logic.GetAllCharacters())
            {
                Console.WriteLine($"| {chrcter.Id,2} | {chrcter.Name,10} | {chrcter.Genus,8} | {chrcter.Age,7} | {chrcter.Level,7} |");
            }

            Console.ReadLine();
        }
    }
}