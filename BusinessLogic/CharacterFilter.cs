using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Класс фильтрации персонажа
    /// </summary>
    public class CharacterFilter : ICharacterFilter
    {
        public IEnumerable<Character> FilterByMinAge(IEnumerable<Character> characters, int minAge)
            => characters.Where(c => c.Age >= minAge);
    }
}
