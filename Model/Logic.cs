using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Logic
    {
        private List<Character> characters = new List<Character>()
        {
            new Character("Бримис", 46),
            new Character("Аэрен", 66),
            new Character("Данудор", 80),
            new Character("Гвинрил", 102),
            new Character("Элалов", 92)
        };

        public List<Character> GetAllCharacters()
        {
            return characters;
        }
    }
}
