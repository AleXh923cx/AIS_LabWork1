using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Интерфейс репозитория для записи сущностей
    /// </summary>
    /// <typeparam name="T">Тип сущности (наследник IDomainObject)</typeparam>
    public interface IWriteRepository<T> where T : IDomainObject
    {
        /// <summary>
        /// Добавить сущность
        /// </summary>
        /// <param name="entity">Добавляемая сущность</param>
        void Add(T entity);
        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        void Delete(int id);
        /// <summary>
        /// Изменить сущность
        /// </summary>
        /// <param name="entity">Изменяемая сущность</param>
        void Update(T entity);
    }
}
