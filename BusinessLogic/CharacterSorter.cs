using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Класс сортировки персонажа
    /// </summary>
    public class CharacterSorter : ICharacterSort
    {
        public IEnumerable<Character> Sort<T>(IEnumerable<Character> characters,
            Func<Character, T> keySelector)
            => characters.OrderBy(keySelector);
    }
}
