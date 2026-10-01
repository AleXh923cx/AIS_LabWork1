using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Logic
    {
        private readonly IRepository<Character> _repository;

        /// <summary>
        /// Конструктор (для тестов)
        /// </summary>
        /// <param name="repository">Репозитория</param>
        public Logic(IRepository<Character> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Конструктор (Entity Framework версия)
        /// </summary>
        public Logic() : this(new DapperRepository<Character>())
        {
            using (var ctx = new DBContext())
            {
                ctx.Database.EnsureCreated();
            }
            SeedIfEmpty();
        }

        /// <summary>
        /// Заполняет список, но только если он пуст
        /// </summary>
        public void SeedIfEmpty()
        {
            if (_repository.ReadAll().Any()) return;

            AddCharacter("Бримис", "Берёза", 46);
            AddCharacter("Аэрен", "Сосна", 66);
            AddCharacter("Данудор", "Тополь", 80);
            AddCharacter("Гвинрил", "Дуб", 102);
            AddCharacter("Элалов", "Клён", 92);
            AddCharacter("Каэрра", "Берёза", 76);
            AddCharacter("Финтин", "Дуб", 70);
            AddCharacter("Дэнлоу", "Сосна", 115);
            AddCharacter("Эладор", "Ель", 38);
            AddCharacter("Циркис", "Тополь", 59);
        }

        /// <summary>
        /// Поиск персонажа по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Персонаж по заданному идентификатору</returns>
        public Character GetCharacterById(int id) => _repository.ReadById(id);

        /// <summary>
        /// Добавление персонажа
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="genus">Вид</param>
        /// <param name="age">Возраст</param>
        public bool AddCharacter(string name, string genus, int age)
        {
            if (!Validation.ValidateCharacter(name, genus, age, out _))
                return false;

            _repository.Add(new Character(0, name, genus, age));
            return true;
        }

        /// <summary>
        /// Удаление персонажа
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public bool DeleteCharacter(int id)
        {
            if (_repository.ReadById(id) == null)
                return false;

            _repository.Delete(id);
            return true;
        }

        /// <summary>
        /// Изменение персонажа
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Имя</param>
        /// <param name="genus">Вид</param>
        /// <param name="age">Возраст</param>
        public bool UpdateCharacter(int id, string name, string genus, int age)
        {
            var character = _repository.ReadById(id);
            if (character == null)
                return false;

            if (!Validation.ValidateCharacter(name, genus, age, out _))
                return false;

            character.Name = name;
            character.Genus = genus;
            character.Age = age;
            _repository.Update(character);
            return true;
        }

        /// <summary>
        /// Возвращает список персонажей с применённой сортировкой и фильтрацией.
        /// </summary>
        /// <param name="sortByGenus">true - сортировка по виду, false - по номеру.</param>
        /// <param name="minAge">Минимальный возраст или null, если фильтр не нужен.</param>
        /// <returns>Обработанные списки персонажей</returns>
        public List<Character> GetProcessedCharacters(bool sortByGenus, int? minAge)
        {
            List<Character> result = _repository.ReadAll().ToList();

            if (sortByGenus)
                result.Sort((a, b) => string.Compare(a.Genus, b.Genus));
            else
                result.Sort((a, b) => a.Id.CompareTo(b.Id));

            if (minAge.HasValue)
                result = result.Where(c => c.Age >= minAge.Value).ToList();

            return result;
        }
    }
}
