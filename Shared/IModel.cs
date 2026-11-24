using System;
using System.Collections.Generic;

namespace Shared
{
    /// <summary>
    /// Модель предметной области: 
    /// загрузка, добавление, обновление и удаление персонажей,
    /// а также уведомление представления о результате операций и ошибках.
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Возникает после успешной загрузки списка персонажей.
        /// </summary>
        event EventHandler<List<CharacterDto>> CharactersLoaded;
        /// <summary>
        /// Возникает при возникновении ошибки; передаёт текст ошибки.
        /// </summary>
        event EventHandler<string> ErrorOccurred;

        /// <summary>
        /// Добавляет нового персонажа.
        /// </summary>
        /// <param name="character">Данные добавляемого персонажа.</param>
        void Add(CharacterDto character);
        /// <summary>
        /// Удаляет персонажа по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор удаляемого персонажа.</param>
        void Delete(int id);
        /// <summary>
        /// Обновляет данные существующего персонажа.
        /// </summary>
        /// <param name="character">Персонаж с обновлёнными данными.</param>
        void Update(CharacterDto character);

        /// <summary>
        /// Загружает персонажей с указанной сортировкой и 
        /// необязательным фильтром по минимальному возрасту.
        /// </summary>
        /// <param name="sortBy">Вариант сортировки списка.</param>
        /// <param name="minAge">Минимальный возраст для фильтрации; 
        /// <c>null</c> — без фильтра.</param>
        void Load(SortOption sortBy, int? minAge);
    }
}
