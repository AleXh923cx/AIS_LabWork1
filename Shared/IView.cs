using System;

namespace Shared
{
    /// <summary>
    /// Представление: отображает данные пользователю и 
    /// транслирует действия пользователя
    /// в события запросов к модели.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Возникает при запросе пользователя добавить персонажа.
        /// </summary>
        event EventHandler<CharacterDto> RequestAdd;
        /// <summary>
        /// Возникает при запросе пользователя обновить данные персонажа.
        /// </summary>
        event EventHandler<CharacterDto> RequestUpdate;
        /// <summary>
        /// Возникает при запросе пользователя удалить персонажа по идентификатору.
        /// </summary>
        event EventHandler<int> RequestDelete;
        /// <summary>
        /// Возникает при запросе пользователя отфильтровать персонажей
        /// по минимальному возрасту;
        /// <c>null</c> означает отсутствие фильтра.
        /// </summary>
        event EventHandler<int?> RequestFilter;

        /// <summary>
        /// Отображает список персонажей.
        /// </summary>
        /// <param name="characters">Список персонажей для отображения.</param>
        void ShowList(List<CharacterDto> characters);
        /// <summary>
        /// Отображает сообщение пользователю.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        void ShowMessage(string message);
    }
}
