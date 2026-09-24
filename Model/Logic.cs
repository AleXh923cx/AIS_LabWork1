using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Logic
    {
        private List<Character> characters = new List<Character>();
        private int _tempId = 1;

        public Logic()
        {
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
        public Character GetCharacterById(int id) => 
            characters.FirstOrDefault(c => c.Id == id);

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

            characters.Add(new Character(_tempId++, name, genus, age));
            return true;
        }

        /// <summary>
        /// Удаление персонажа
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public bool DeleteCharacter(int id)
        {
            Character character = GetCharacterById(id);
            if (character == null)
                return false;

            characters.Remove(character);
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
            Character character = GetCharacterById(id);
            if (character == null)
                return false;

            if (!Validation.ValidateCharacter(name, genus, age, out _))
                return false;

            character.Name = name;
            character.Genus = genus;
            character.Age = age;
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
            List<Character> result = new List<Character>(characters);

            if (sortByGenus)
                result.Sort((a, b) => string.Compare(a.Genus, b.Genus, StringComparison.Ordinal));
            else
                result.Sort((a, b) => a.Id.CompareTo(b.Id));

            if (minAge.HasValue)
                result = result.Where(c => c.Age >= minAge.Value).ToList();

            return result;
        }
    }
}
