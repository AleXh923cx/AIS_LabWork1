using System;
using Model;

namespace View_ConsoleApp
{
    class Program
    {
        static Logic logic = new Logic();

        static void ShowMenu()
        {
            Console.WriteLine("АИС \"РПГ персонажи-дерево\"");
            Console.WriteLine();
            Console.WriteLine("Пункты:");
            Console.WriteLine("1. Добавление сущности");
            Console.WriteLine("2. Удаление сущности");
            Console.WriteLine("3. Изменение сущности");
            Console.WriteLine("4. Просмотр таблиц");
            Console.WriteLine("5. Сортировка по виду");
            Console.WriteLine("0. Выход\n");

            Console.Write("Выберите пункт: ");
        }

        static void ShowTable()
        {
            // Заголовки таблицы
            Console.WriteLine("| №  |    Имя     |   Вид    | Возраст | Уровень |");
            Console.WriteLine("|----|------------|----------|---------|---------|");

            // Записи таблицы
            foreach (var chrcter in logic.GetAllCharacters())
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
                    ShowTable();

                    Console.WriteLine();
                    Console.WriteLine("Нажмите любую клавишу для выхода из режима таблицы ...");
                    Console.ReadKey();

                    tableMode = false;
                    Console.Clear();
                }
                else
                {
                    ShowMenu();
                    if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice < 6)
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
                            case 0:
                                cycleMenu = false;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод! (диапазон ввода: 0-5)");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }
    }
}