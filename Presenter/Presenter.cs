using Shared;
using System;
using System.Collections.Generic;

namespace Presenter
{
    /// <summary>
    /// Презентер, связывающий модель с представлением:
    /// подписывается на события модели и инициирует загрузку данных.
    /// </summary>
    public class Presenter
    {
        private readonly IModel _model;

        /// <summary>
        /// Конструктор c подписыванием на события указанной модели.
        /// </summary>
        /// <param name="model">Модель предметной области.</param>
        public Presenter(IModel model)
        {
            _model = model;

            _model.CharactersLoaded += OnCharactersLoaded;
            _model.ErrorOccurred += OnErrorOccurred;
        }

        private void OnCharactersLoaded(object? sender, List<CharacterDto> e)
        {
            Console.WriteLine($"ЗАГРУЗКА УСПЕШНА. Получено персонажей: {e.Count()}");
            foreach (CharacterDto character in e)
            {
                Console.WriteLine($"{character.Name} (возраст: {character.Age})");
            }
        }

        private void OnErrorOccurred(object? sender, string e)
        {
            Console.WriteLine($"ОШИБКА ПРЕЗЕНТЕРА: {e}");
        }

        /// <summary>
        /// Запускает работу презентера: инициирует начальную загрузку персонажей
        /// с сортировкой по идентификатору и без фильтра по возрасту.
        /// </summary>
        public void Start()
        {
            _model.Load(SortOption.ById, null);
        }
    }
}
