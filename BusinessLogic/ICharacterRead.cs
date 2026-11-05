using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    /// <summary>
    /// Интерфейс чтение персонажа
    /// </summary>
    public interface ICharacterRead
    {
        /// <summary>
        /// Поиск персонажа по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор персонажа</param>
        /// <returns>Персонаж по заданному идентификатору</returns>
        Character? GetCharacterById(int id);
        /// <summary>
        /// Получение всех персонажей
        /// </summary>
        /// <returns>Коллекция всех персонажей</returns>
        IEnumerable<Character> GetAllCharacters();
    }
}
