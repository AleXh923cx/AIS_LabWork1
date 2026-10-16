using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Интерфейс репозитория для чтения сущностей
    /// </summary>
    /// <typeparam name="T">Тип сущности (наследник IDomainObject)</typeparam>
    public interface IReadRepository<T> where T : IDomainObject
    {
        /// <summary>
        /// Получить все сущности
        /// </summary>
        /// <returns>Коллекция всех сущностей</returns>
        IEnumerable<T> ReadAll();
        /// <summary>
        /// Получить сущность по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <returns>Найденная сущность</returns>
        T ReadById(int id);
    }
}
