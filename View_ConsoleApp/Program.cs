using System;
using Model;

namespace View_ConsoleApp
{
    class Program
    {
        static Logic logic = new Logic();

        static string ReadText(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
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
                Console.WriteLine(message);

                if (int.TryParse(Console.ReadLine(), out int number) && number >= minNumber)
                {
                    return number;
                }

                Console.WriteLine($"ОШИБКА: Введите целое число не меньше {minNumber}.");
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("АИС \"РПГ персонажи-дерево\"");
            Console.WriteLine();
            Console.WriteLine("Пункты:");
            Console.WriteLine("1. Добавление персонажа");
            Console.WriteLine("2. Удаление персонажа");
            Console.WriteLine("3. Изменение персонажа");
            Console.WriteLine("4. Просмотр таблиц");
            Console.WriteLine("5. Сортировка по виду");
            Console.WriteLine("6. Выборка по более минимального возраста");
            Console.WriteLine("0. Выход\n");

            Console.Write("Выберите пункт: ");
        }

        static void ShowTable(List<Character> charList)
        {
            // Заголовки таблицы
            Console.WriteLine("| №  |    Имя     |   Вид    | Возраст | Уровень |");
            Console.WriteLine("|----|------------|----------|---------|---------|");

            // Записи таблицы
            foreach (var chrcter in charList)
            {
                Console.WriteLine($"| {chrcter.Id,2} | {chrcter.Name,10} | {chrcter.Genus,8} | {chrcter.Age,7} | {chrcter.Level,7} |");
            }
        }

        static void Main(string[] args)
        {
            bool cycleMenu = true;
            bool tableMode = false;

            while (cycleMenu)
            {
                if (tableMode)
                {
                    ShowTable(logic.GetAllCharacters());

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
                    if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice < 7)
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.Write("Введите имя персонажа: ");
                                string charName = Console.ReadLine();
                                if (string.IsNullOrEmpty(charName))
                                {
                                    Console.WriteLine("ОШИБКА: Имя персонажа не должно быть пустым");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                Console.Write("Введите вид персонажа: ");
                                string charCls = Console.ReadLine();
                                if (string.IsNullOrEmpty(charCls))
                                {
                                    Console.WriteLine("ОШИБКА: Вид персонажа не должно быть пустым");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                Console.Write("Введите возраст персонажа: ");
                                if (int.TryParse(Console.ReadLine(), out int charAge))
                                {
                                    if (charAge < 0)
                                    {
                                        Console.WriteLine("ОШИБКА: Возраст должен быть выше нуля");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    }
                                    logic.AddCharacter(charName, charCls, charAge);
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("ОШИБКА: Возраст должен быть числом");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                            case 2:
                                Console.Write("Введите № персонажа: ");
                                if (int.TryParse(Console.ReadLine(), out int charId))
                                {
                                    if (!logic.DeleteCharacter(charId))
                                    {
                                        Console.WriteLine("ОШИБКА: Введённый № персонажа не существует в таблице");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    }
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("ОШИБКА: № персонажа должен быть числом");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                            case 3:
                                Console.Write("Введите № персонажа: ");
                                if (int.TryParse(Console.ReadLine(), out charId))
                                {
                                    if (logic.GetCharacterById(charId) == null)
                                    {
                                        Console.WriteLine("ОШИБКА: Введённый № персонажа не существует в таблице");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    }
                                    else
                                    {
                                        Console.Write("Введите имя персонажа: ");
                                        charName = Console.ReadLine();
                                        if (string.IsNullOrEmpty(charName))
                                        {
                                            Console.WriteLine("ОШИБКА: Имя персонажа не должно быть пустым");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                        Console.Write("Введите вид персонажа: ");
                                        charCls = Console.ReadLine();
                                        if (string.IsNullOrEmpty(charCls))
                                        {
                                            Console.WriteLine("ОШИБКА: Вид персонажа не должно быть пустым");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                        Console.Write("Введите возраст персонажа: ");
                                        if (int.TryParse(Console.ReadLine(), out charAge))
                                        {
                                            if (charAge < 0)
                                            {
                                                Console.WriteLine("ОШИБКА: Возраст должен быть выше нуля");
                                                Console.ReadKey();
                                                Console.Clear();
                                                break;
                                            }

                                            logic.UpdateCharacter(charId, charName, charCls, charAge);
                                            Console.Clear();
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("ОШИБКА: Возраст должен быть числом");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ОШИБКА: № персонажа должен быть числом");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                            case 4:
                                tableMode = true;
                                Console.Clear();
                                break;
                            case 5:
                                logic.SortCharacterByGenus();
                                tableMode = true;
                                Console.Clear();
                                break;
                            case 6:
                                Console.Write("Введите минимальный возраст: ");
                                if (int.TryParse(Console.ReadLine(), out int minAge))
                                {
                                    if (minAge < 0)
                                    {
                                        Console.WriteLine("ОШИБКА: Минимальный возраст должен быть выше нуля");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    }

                                    Console.Clear();
                                    ShowTable(logic.GetCharacterListByAge(minAge));
                                }
                                else
                                {
                                    Console.WriteLine("ОШИБКА: Минимальный возраст должен быть числом");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }

                                Console.WriteLine();
                                Console.WriteLine("Нажмите любую клавишу для возврата в меню ...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 0:
                                cycleMenu = false;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод! (диапазон ввода: 0-6)");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }
    }
}