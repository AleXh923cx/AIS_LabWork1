using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Logic
    {
        private List<Character> characters = new List<Character>()
        {
            new Character(1, "Бримис", 46),
            new Character(2, "Аэрен", 66),
            new Character(3, "Данудор", 80),
            new Character(4, "Гвинрил", 102),
            new Character(5, "Элалов", 92)
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
