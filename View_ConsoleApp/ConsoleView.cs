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
                    case "1":
                        AddCharacter();
                        break;
                    case "2":
                        DeleteCharacter();
                        break;
                    case "3":
                        UpdateCharacter();
                        break;
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
                    case "6":
                        string ageInput = ReadInput("Введите минимальный возраст: ");
                        if (!Validation.TryParseAge(ageInput, out int minAge, out string error))
                            Console.WriteLine($"ОШИБКА: {error}");
                        else
                            MinAge = minAge;
                        RequestFilter?.Invoke(this, MinAge);
                        break;
                    case "7":
                        MinAge = null;
                        RequestFilter?.Invoke(this, MinAge);
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

        /// <summary>
        /// Выводит приглашение к вводу в консоль и читает введённую пользователем строку.
        /// </summary>
        /// <param name="message">Текст приглашения перед вводом</param>
        /// <returns>Введённая пользователем строка или <c>null</c>, если поток ввода закрыт.</returns>
        private static string ReadInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
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

        private void AddCharacter()
        {
            while (true)
            {
                string charName = ReadInput("Введите имя персонажа: ");
                string charGenus = ReadInput("Введите вид персонажа: ");
                string charAgeInput = ReadInput("Введите возраст персонажа: ");

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

                RequestAdd?.Invoke(this, new CharacterDto(
                    0, charName, charGenus, charAge));
                Console.Clear();
                PrintCharacters();
                Console.WriteLine($"Персонаж добавлен.");
                return;
            }
        }

        private void DeleteCharacter()
        {
            string idInput = ReadInput("Введите № персонажа: ");
            if (!Validation.TryParseId(idInput, out int id, out string idError))
            {
                Console.WriteLine($"ОШИБКА: {idError}");
                return;
            }
            RequestDelete?.Invoke(this, id);
            Console.Clear();
            PrintCharacters();
            Console.WriteLine($"Персонаж удалён.");
        }

        private void UpdateCharacter()
        {
            string idInput = ReadInput("Введите № персонажа: ");
            if (!Validation.TryParseId(idInput, out int id, out string error))
            {
                Console.WriteLine($"ОШИБКА: {error}");
                return;
            }

            string charName = ReadInput("Введите имя: ");
            string charGenus = ReadInput("Введите вид: ");
            string charAgeInput = ReadInput("Введите возраст: ");

            if (!Validation.TryParseAge(charAgeInput, out int charAge, out error))
            {
                Console.WriteLine($"ОШИБКА: {error}");
                return;
            }

            if (!Validation.ValidateCharacter(charName, charGenus, charAge, out error))
            {
                Console.WriteLine($"ОШИБКА: {error}");
                return;
            }

            RequestUpdate?.Invoke(this, new CharacterDto(
                id, charName, charGenus, charAge));
            Console.Clear();
            PrintCharacters();
            Console.WriteLine("Персонаж изменён.");
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
