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
        private readonly IView _view;

        /// <summary>
        /// Конструктор c подписыванием на события указанной модели.
        /// </summary>
        /// <param name="model">Модель предметной области.</param>
        public Presenter(IModel model, IView view)
        {
            _model = model;
            _view = view;

            Subscribe();
        }

        /// <summary>
        /// Подписывает событие модели и вьюхи
        /// </summary>
        private void Subscribe()
        {
            // Подписка модели
            _model.CharactersLoaded += OnCharactersLoaded;
            _model.ErrorOccurred += OnErrorOccurred;

            // Подписка вьюхи
            _view.RequestSort += OnRequestSort;
        }

        private void OnCharactersLoaded(object? sender, List<CharacterDto> e)
        {
            _view.ShowList(e);
        }

        private void OnErrorOccurred(object? sender, string e)
        {
            _view.ShowMessage(e);
        }

        private void OnRequestSort(object? sender, SortOption sortOption)
        {
            
        }

        /// <summary>
        /// Запускает работу презентера: инициирует начальную загрузку персонажей
        /// с сортировкой по идентификатору и без фильтра по возрасту, а затем
        /// по свойству ViewType запускает вьюху.
        /// </summary>
        public void Start()
        {
            _model.Load(SortOption.ById, null);
            _view.Run();
        }
    }
}
