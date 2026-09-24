using System;
using Model;

namespace View_ConsoleApp
{
    class Program
    {
        static Logic logic = new Logic();

        static bool IsSortByGenus = false;
        static int? MinAge = null;

        static string ReadText(string message)
        {
            while (true)
            {
                Console.Write(message);
                string text = Console.ReadLine();

                if (!string.IsNullOrEmpty(text))
                    return text;

                Console.WriteLine("ОШИБКА: Значение не должно быть пустым.");
            }
        }

        static int ReadNumber(string message, int minNumber)
        {
            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out int number) && number >= minNumber)
                {
                    return number;
                }

                Console.WriteLine($"ОШИБКА: Введите целое число не меньше {minNumber}.");
            }
        }

        static void AddCharacter()
        {
            string charName = ReadText("Введите имя персонажа: ");
            string charGenus = ReadText("Введите вид персонажа: ");
            int charAge = ReadNumber("Введите возраст персонажа: ", 0);

            logic.AddCharacter(charName, charGenus, charAge);
            Console.WriteLine($"Персонаж добавлен.");
            Console.ReadKey();
        }

        static void DeleteCharacter()
        {
            int id = ReadNumber("Введите № персонажа: ", 1);

            if (logic.DeleteCharacter(id))
                Console.WriteLine("Персонаж удалён.");
            else
                Console.WriteLine("Персонаж не найден.");
        }

        static void UpdateCharacter()
        {
            int id = ReadNumber("Введите № персонажа: ", 1);

            if (logic.GetCharacterById(id) == null)
            {
                Console.WriteLine("Персонаж не найден.");
                return;
            }

            string charName = ReadText("Введите имя: ");
            string charGenus = ReadText("Введите вид: ");
            int charAge = ReadNumber("Введите возраст: ", 0);

            logic.UpdateCharacter(id, charName, charGenus, charAge);
            Console.WriteLine("Персонаж изменён.");
        }

        static void ShowMenu()
        {
            Console.WriteLine("АИС \"РПГ персонажи-дерево\"");
            Console.WriteLine();
            Console.WriteLine($"Сортировка: {(IsSortByGenus ? "по виду" : "по №")}");
            Console.WriteLine($"Минимальный возраст: {(MinAge.HasValue ? MinAge.Value.ToString() : "не задан")}");
            Console.WriteLine();
            Console.WriteLine("Пункты:");
            Console.WriteLine("1. Добавление персонажа");
            Console.WriteLine("2. Удаление персонажа");
            Console.WriteLine("3. Изменение персонажа");
            Console.WriteLine("4. Просмотр таблиц");
            Console.WriteLine("5. Переключить сортировку");
            Console.WriteLine("6. Выборка по возрасту");
            Console.WriteLine("7. Сбросить выборку");
            Console.WriteLine("0. Выход\n");

            Console.Write("Выберите пункт: ");
        }

        static void ShowTable()
        {
            if (IsSortByGenus)
                logic.SortCharacterByGenus();
            else
                logic.SortCharacterById();

            var charLists = MinAge.HasValue ?
                logic.GetCharacterListByAge(MinAge.Value) :
                logic.GetAllCharacters();

            // Заголовки таблицы
            Console.WriteLine("| №  |    Имя     |   Вид    | Возраст | Уровень |");
            Console.WriteLine("|----|------------|----------|---------|---------|");

            // Записи таблицы
            foreach (var chrcter in charLists)
            {
                Console.WriteLine($"| {chrcter.Id,2} | {chrcter.Name,10} | {chrcter.Genus,8} | {chrcter.Age,7} | {chrcter.Level,7} |");
            }

            if (charLists.Count == 0)
                Console.WriteLine("Персонажи не найдены.");
        }

        static void Main(string[] args)
        {
            bool cycleMenu = true;
            bool tableMode = false;

            while (cycleMenu)
            {
                if (tableMode)
                {
                    ShowTable();

                    Console.WriteLine();
                    Console.WriteLine("Нажмите любую клавишу для выхода из режима таблицы ...");
                    Console.ReadKey();

                    tableMode = false;
                    Console.Clear();
                    logic.SortCharacterById();
                }
                else
                {
                    ShowMenu();
                    if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice < 8)
                    {
                        switch (choice)
                        {
                            case 1:
                                AddCharacter();
                                Console.Clear();
                                break;
                            case 2:
                                DeleteCharacter();
                                Console.Clear();
                                break;
                            case 3:
                                UpdateCharacter();
                                Console.Clear();
                                break;
                            case 4:
                                tableMode = true;
                                Console.Clear();
                                break;
                            case 5:
                                IsSortByGenus = !IsSortByGenus;
                                Console.Clear();
                                break;
                            case 6:
                                MinAge = ReadNumber("Введите минимальный возраст: ", 0);
                                ShowTable();
                                break;
                            case 7:
                                MinAge = null;
                                ShowTable();
                                break;
                            case 0:
                                cycleMenu = false;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод! (диапазон ввода: 0-7)");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }
    }
}