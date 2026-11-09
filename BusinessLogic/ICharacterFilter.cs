using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Интерфейс фильтрации персонажа
    /// </summary>
    public interface ICharacterFilter
    {
        /// <summary>
        /// Фильтрует персонажей из коллекции по минимальному возрасту
        /// </summary>
        /// <param name="characters">Коллекция персонажей</param>
        /// <param name="minAge">Минимальный возраст</param>
        /// <returns>Коллекция отфильтрованных персонажей</returns>
        IEnumerable<Character> FilterByMinAge(IEnumerable<Character> characters, int minAge);
    }

    /// <summary>
    /// Класс фильтрации персонажа
    /// </summary>
    public class CharacterFilter : ICharacterFilter
    {
        public IEnumerable<Character> FilterByMinAge(IEnumerable<Character> characters, int minAge)
            => characters.Where(c => c.Age >= minAge);
    }
}
