using System;
using Model;

namespace View_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();

            bool cycleMenu = true;

            while (cycleMenu)
            {
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
                        case 1:
                            Console.Write("Введите имя персонажа: ");
                            string charName = Console.ReadLine();
                            Console.Write("Введите вид персонажа: ");
                            string charClsName = Console.ReadLine();
                            Console.Write("Введите возраст персонажа: ");
                            int charAgeName = int.Parse(Console.ReadLine());
                            logic.AddCharacter(charName, charClsName, charAgeName);
                            Console.Clear();
                            break;
                        case 2:
                            Console.Write("Введите № персонажа: ");
                            int charId = int.Parse(Console.ReadLine());
                            logic.DeleteCharacter(charId);
                            Console.Clear();
                            break;
                        case 0:
                            cycleMenu = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод! (диапазон ввода: 0-2)");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}