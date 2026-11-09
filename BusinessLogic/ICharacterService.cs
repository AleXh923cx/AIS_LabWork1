using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Интерфейс службы персонажа (фасад бизнес-логики)
    /// </summary>
    public interface ICharacterService : 
        ICharacterRead, ICharacterWrite
    {
        /// <summary>
        /// Возвращает список персонажей с применённой сортировкой и фильтрацией
        /// </summary>
        /// <param name="sortKey">Сортировка по выбранному ключу (свойству)</param>
        /// <param name="minAge">Минимальный возраст или null, если фильтр не нужен</param>
        /// <returns>Обработанный список персонажей</returns>
        List<Character> GetProcessedCharacters<T>(Func<Character, T> sortKey, int? minAge);
    }
}
