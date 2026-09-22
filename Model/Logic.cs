using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Logic
    {
        // private List<Character> characters = new List<Character>()
        // {
        //     new Character(1, "Бримис", "Берёза", 46),
        //     new Character(2, "Аэрен", "Сосна", 66),
        //     new Character(3, "Данудор", "Тополь", 80),
        //     new Character(4, "Гвинрил", "Дуб", 102),
        //     new Character(5, "Элалов", "Клён", 92),
        //     new Character(6, "Каэрра", "Берёза", 76),
        //     new Character(7, "Финтин", "Дуб", 70),
        //     new Character(8, "Дэнлоу", "Сосна", 115),
        //     new Character(9, "Эладор", "Ель", 38),
        //     new Character(10, "Циркис", "Тополь", 59)
        // };

        private List<Character> characters = new List<Character>();
        private int _tempId = 1;

        /// <summary>
        /// </summary>
        /// <returns>Cписок персонажей-деревьев</returns>
        public List<Character> GetAllCharacters()
        {
            return characters;
        }

        public Character GetCharacterById(int id)
        {
            foreach (Character character in characters)
            {
                if (character.Id == id) return character;
            }

            return null; // "Не нашли по ключу - получи пустоту"
        }

        /// <summary>
        /// Добавление
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="genus">Вид</param>
        /// <param name="age">Возраст</param>
        public bool AddCharacter(string name, string genus, int age)
        {
            if (name == null || genus == null || age < 0)
                return false;

            Character character = new Character(_tempId, name, genus, age);
            characters.Add(character);
            _tempId++;
            return true;
        }

        /// <summary>
        /// Удаление
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
    }
}
