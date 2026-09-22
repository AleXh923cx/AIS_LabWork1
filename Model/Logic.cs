using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Logic
    {
        private List<Character> characters = new List<Character>()
        {
            new Character(1, "Бримис", "Берёза", 46),
            new Character(2, "Аэрен", "Сосна", 66),
            new Character(3, "Данудор", "Тополь", 80),
            new Character(4, "Гвинрил", "Дуб", 102),
            new Character(5, "Элалов", "Клён", 92),
            new Character(6, "Каэрра", "Берёза", 76),
            new Character(7, "Финтин", "Дуб", 70),
            new Character(8, "Дэнлоу", "Сосна", 115),
            new Character(9, "Эладор", "Ель", 38),
            new Character(10, "Циркис", "Тополь", 59)
        };

        /// <summary>
        /// </summary>
        /// <returns>Cписок персонажей-деревьев</returns>
        public List<Character> GetAllCharacters()
        {
            return characters;
        }
    }
}
