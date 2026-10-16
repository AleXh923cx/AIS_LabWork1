using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Базовый интерфейс репозитория для работы с сущностями
    /// </summary>
    /// <typeparam name="T">Тип сущности (наследник IDomainObject)</typeparam>
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> 
        where T : IDomainObject
    {
        
    }
}
