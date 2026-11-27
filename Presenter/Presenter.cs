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
        /// <summary>
        /// Хранимый только для чтение - модель (CharacterModel
        /// </summary>
        private readonly IModel _model;
        /// <summary>
        /// Хранимый только для чтение - вьюха (либо WinForms, либо Console,
        /// по App.config - ViewType)
        /// </summary>
        private readonly IView _view;

        /// <summary>
        /// Хранимый текущий вариант сортировок для Презентера.
        /// </summary>
        private SortOption _currentSortOption = SortOption.ById;
        /// <summary>
        /// Хранимый текущий минимальный возраст для Презентера.
        /// </summary>
        private int? _currentMinAge;

        /// <summary>
        /// Конструктор c подписыванием на события указанной модели.
        /// </summary>
        /// <param name="model">Модель предметной области.</param>
        /// <param name="view">Вьюха предметной области.</param>
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
            _model.OperationSucceeded += OnOperationSucceeded;

            // Подписка вьюхи
            _view.RequestAdd += OnRequestAdd;
            _view.RequestDelete += OnRequestDelete;
            _view.RequestUpdate += OnRequestUpdate;
            _view.RequestSort += OnRequestSort;
            _view.RequestFilter += OnRequestFilter;
        }

        private void OnCharactersLoaded(object? sender, List<CharacterDto> e)
        {
            _view.ShowList(e);
        }

        private void OnErrorOccurred(object? sender, string e)
        {
            _view.ShowMessage(e);
        }

        private void OnOperationSucceeded(object? sender, OperationResult e)
        {
            _view.ShowOperationResult(e);
        }

        private void OnRequestAdd(object? sender, CharacterDto character)
        {
            _model.Add(character);
        }

        private void OnRequestDelete(object? sender, int id)
        {
            _model.Delete(id);
        }

        private void OnRequestUpdate(object? sender, CharacterDto character)
        {
            _model.Update(character);
        }

        private void OnRequestSort(object? sender, SortOption sortOption)
        {
            _currentSortOption = sortOption;
            _model.Load(_currentSortOption, _currentMinAge);
        }

        private void OnRequestFilter(object? sender, int? minAge)
        {
            _currentMinAge = minAge;
            _model.Load(_currentSortOption, _currentMinAge);
        }

        /// <summary>
        /// Запускает работу презентера: инициирует начальную загрузку персонажей
        /// с сортировкой по идентификатору и без фильтра по возрасту, а затем
        /// по свойству ViewType запускает вьюху.
        /// </summary>
        public void Start()
        {
            _model.Load(_currentSortOption, _currentMinAge);
            _view.Run();
        }
    }
}
