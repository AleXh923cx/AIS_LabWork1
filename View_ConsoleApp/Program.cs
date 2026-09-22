using System;
using Model;

namespace View_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();

            // Заголовки таблицы
            Console.WriteLine("| №  |    Имя     |   Вид    | Возраст | Уровень |");
            Console.WriteLine("|----|------------|----------|---------|---------|");

            // Записи таблицы
            foreach (var chrcter in logic.GetAllCharacters())
            {
                Console.WriteLine($"| {chrcter.Id,2} | {chrcter.Name,10} | {chrcter.Genus,8} | {chrcter.Age,7} | {chrcter.Level,7} |");
            }

            Console.WriteLine();
            Console.WriteLine("Пункты:");
            Console.WriteLine("1. Добавление сущности");
            Console.WriteLine("2. Удаление сущности");
            Console.WriteLine("0. Выход\n");

            Console.Write("Выберите пункт: "); string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int choice) && choice >= 0 && choice < 3)
            {
                switch (choice)
                {
                    case 0:
                        return; // Конец
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }
    }
}