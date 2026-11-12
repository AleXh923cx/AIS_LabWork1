using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Интерфейс сортировки персонажа
    /// </summary>
    public interface ICharacterSort
    {
        /// <summary>
        /// Сортирует коллекцию персонажей по заданному критерию (ключу)
        /// </summary>
        /// <typeparam name="T">Тип свойства</typeparam>
        /// <param name="characters">Коллекция персонажей</param>
        /// <param name="keySelector">Выбор ключа сортировки 
        /// <br>(можно c => c.Id, либо c => c.Genus и т.д.)</br></param>
        /// <returns>Отсортированная коллекция персонажей</returns>
        IEnumerable<Character> Sort<T>(IEnumerable<Character> characters,
            Func<Character, T> keySelector);
    }
}
