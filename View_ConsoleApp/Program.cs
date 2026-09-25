using System;
using Model;

namespace View_ConsoleApp
{
    class Program
    {
        static Logic logic = new Logic();
        static bool IsSortByGenus = false;
        static int? MinAge = null;

        /// <summary>
        /// Читает ввод со строки
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <returns>Ввод пользователя</returns>
        static string ReadLine(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

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
            while (true)
            {
                string charName = ReadLine("Введите имя персонажа: ");
                string charGenus = ReadLine("Введите вид персонажа: ");
                string charAgeInput = ReadLine("Введите возраст персонажа: ");

                if (!Validation.TryParseAge(charAgeInput, out int charAge, out string error))
                {
                    Console.WriteLine($"ОШИБКА: {error}");
                    continue;
                }

                if (!Validation.ValidateCharacter(charName, charGenus, charAge, out error))
                {
                    Console.WriteLine($"ОШИБКА: {error}");
                    continue;
                }

                Console.WriteLine("Не удалось добавить персонажа.");

                logic.AddCharacter(charName, charGenus, charAge);
                Console.WriteLine($"Персонаж добавлен.");
                return;
            }
        }

        static void DeleteCharacter()
        {
            string idInput = ReadLine("Введите № персонажа: ");

            if (!Validation.TryParseId(idInput, out int id, out string error))
            {
                Console.WriteLine($"ОШИБКА: {error}");
                return;
            }

            if (!logic.DeleteCharacter(id))
            {
                Console.WriteLine("Персонаж не найден.");
                return;
            }

            Console.WriteLine("Персонаж удалён.");
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

            if (logic.UpdateCharacter(id, charName, charGenus, charAge))
                Console.WriteLine("Персонаж изменён.");
            else
                Console.WriteLine("Не удалось изменить персонажа.");
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
            var list = logic.GetProcessedCharacters(IsSortByGenus, MinAge);

            // Заголовки таблицы
            Console.WriteLine("| №  |    Имя     |   Вид    | Возраст | Уровень |");
            Console.WriteLine("|----|------------|----------|---------|---------|");

            // Записи таблицы
            foreach (var chrcter in list)
                Console.WriteLine($"| {chrcter.Id,2} | {chrcter.Name,10} | {chrcter.Genus,8} | {chrcter.Age,7} | {chrcter.Level,7} |");

            if (list.Count == 0)
                Console.WriteLine("Персонажи не найдены.");
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                ShowMenu();

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": AddCharacter(); break;
                    case "2": DeleteCharacter(); break;
                    case "3": UpdateCharacter(); break;

                    case "4":
                        Console.Clear();
                        ShowTable();
                        break;

                    case "5": IsSortByGenus = !IsSortByGenus; break;
                    case "6": MinAge = ReadNumber("Введите минимальный возраст: ", 0); break;
                    case "7": MinAge = null; break;

                    case null:
                    case "0": return;

                    default:
                        Console.WriteLine("Неверный ввод! (диапазон ввода: 0-7)");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                Console.ReadKey(true);
            }
        }
    }
}