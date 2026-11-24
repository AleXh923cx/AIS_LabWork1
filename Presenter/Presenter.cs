using Shared;
using System;
using System.Collections.Generic;

namespace Presenter
{
    public class Presenter
    {
        private readonly IModel _model;

        public Presenter(IModel model)
        {
            _model = model;

            _model.CharactersLoaded += OnCharactersLoaded;
            _model.ErrorOccurred += OnErrorOccurred;
        }

        private void OnCharactersLoaded(object? sender, List<CharacterDto> e)
        {
            Console.WriteLine("ЗАГРУЗКА УСПЕШНА");
        }

        private void OnErrorOccurred(object? sender, string e)
        {
            Console.WriteLine("ОШИБКА ПРЕЗЕНТЕРА");
        }

        public void Start()
        {
            _model.Load(SortOption.ById, null);
        }
    }
}
