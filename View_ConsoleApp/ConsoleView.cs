using BusinessLogic;
using Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace View_ConsoleApp
{
    public class ConsoleView : IView
    {
        public static int? MinAge;
        public static SortOption sortOption = SortOption.ById;

        private List<CharacterDto> _lastCharacters = new List<CharacterDto>();

        public event EventHandler<CharacterDto>? RequestAdd;
        public event EventHandler<CharacterDto>? RequestUpdate;
        public event EventHandler<int>? RequestDelete;
        public event EventHandler<int?>? RequestFilter;
        public event EventHandler<SortOption>? RequestSort;

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                ShowMenu();

                string choices = Console.ReadLine();
                switch (choices)
                {
                    case "4":
                        Console.Clear();
                        PrintCharacters();
                        break;
                    case "5":
                        sortOption = sortOption == SortOption.ById
                            ? SortOption.ByGenus
                            : SortOption.ById;

                        RequestSort?.Invoke(this, sortOption);
                        break;
                    case null:
                    case "0": return;
                    default:
                        Console.WriteLine("Неверный ввод! (диапазон ввода: 0-7)");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                Console.ReadKey();
            }
        }

        public void ShowList(List<CharacterDto> characters)
        {
            _lastCharacters = characters ?? new List<CharacterDto>();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        private void PrintCharacters()
        {
            // Заголовки таблицы
            Console.WriteLine("| №  |      Имя       |      Вид     | Возраст | Уровень |");
            Console.WriteLine("|----|----------------|--------------|---------|---------|");

            // Записи таблицы
            foreach (var chrcter in _lastCharacters.ToList())
                Console.WriteLine(
                    $"| {chrcter.Id,2} | " +
                    $"{chrcter.Name.PadRight(14)} | " +
                    $"{chrcter.Genus.PadRight(12)} | " +
                    $"{chrcter.Age.ToString().PadRight(7)} | " +
                    $"{chrcter.Level.ToString().PadRight(7)} |");

            if (_lastCharacters.Count() == 0)
                Console.WriteLine("Персонажи не найдены.");
        }

        private void ShowMenu()
        {
            Console.WriteLine("АИС \"РПГ персонажи-дерево\"");
            Console.WriteLine();
            Console.WriteLine($"Сортировка: {(sortOption == SortOption.ByGenus ? "по виду" : "по №")}");
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
    }
}
