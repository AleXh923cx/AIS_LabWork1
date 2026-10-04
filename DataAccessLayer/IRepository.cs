using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Базовый интерфейс репозитория для работы с сущностями
    /// </summary>
    /// <typeparam name="T">Тип сущности (наследник IDomainObject)</typeparam>
    public interface IRepository<T> where T : IDomainObject
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
        /// <summary>
        /// Изменить сущность
        /// </summary>
        /// <param name="entity">Изменяемая сущность</param>
        void Update(T entity);
    }
}
