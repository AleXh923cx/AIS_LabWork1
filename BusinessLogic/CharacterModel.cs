using Model;
using Shared;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    /// <summary>
    /// Реализация <see cref="IModel"/> на основе фасада <see cref="ICharacterService"/>.
    /// </summary>
    public class CharacterModel : IModel
    {
        private readonly ICharacterService _facade;

        public event EventHandler<List<CharacterDto>>? CharactersLoaded;
        public event EventHandler<string>? ErrorOccurred;
        public event EventHandler<OperationResult>? OperationSucceeded;

        private SortOption _currentSortOption = SortOption.ById;
        private int? _currentMinAge;

        public CharacterModel(ICharacterService facade)
        {
            _facade = facade;
        }

        public void Add(CharacterDto character)
        {
            try
            {
                var result = _facade.AddCharacter(
                    character.Name, character.Genus, character.Age
                );

                if (!result.Success)
                {
                    ErrorOccurred?.Invoke(this, "Не удалось добавить персонажа: " +
                        $"{result.ErrorMessage}");
                    return;
                }

                OperationSucceeded?.Invoke(this,
                    new OperationResult(true, "Персонаж добавлен.",
                    canCloseSubform: true));
                Reload();
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, $"Не удалось добавить персонажа: {ex.Message}");
            }
        }

        public void Delete(int id)
        {
            try
            {
                var result = _facade.DeleteCharacter(id);
                
                if (!result.Success)
                {
                    ErrorOccurred?.Invoke(this, "Не удалось удалить персонажа: " +
                        $"{result.ErrorMessage}");
                    return;
                }

                OperationSucceeded?.Invoke(this,
                    new OperationResult(true, "Персонаж удалён.", 
                    canCloseSubform: true));
                Reload();
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, $"Не удалось удалить персонажа: {ex.Message}");
            }
        }

        public void Update(CharacterDto character)
        {
            try
            {
                var result = _facade.UpdateCharacter(
                    character.Id, character.Name, character.Genus, character.Age
                );

                if (!result.Success)
                {
                    ErrorOccurred?.Invoke(this, "Не удалось изменить персонажа: " +
                        $"{result.ErrorMessage}");
                    return;
                }

                OperationSucceeded?.Invoke(this,
                    new OperationResult(true, "Персонаж изменён.", 
                    canCloseSubform: true));
                Reload();
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, $"Не удалось изменить персонажа: {ex.Message}");
            }
        }

        public void Load(SortOption sortBy, int? minAge)
        {
            _currentSortOption = sortBy;
            _currentMinAge = minAge;

            Reload();
        }

        private void Reload()
        {
            try
            {
                Func<Character, object> sortKey = _currentSortOption switch
                {
                    SortOption.ById => c => c.Id,
                    SortOption.ByGenus => c => c.Genus,
                    _ => c => c.Id // на всякий случай
                };

                var characters = _facade.GetProcessedCharacters(sortKey, _currentMinAge);

                var characterDtos = characters
                    .Select(c => new CharacterDto(c.Id, c.Name, c.Genus, c.Age))
                    .ToList();

                CharactersLoaded?.Invoke(this, characterDtos);
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, $"Ошибка при загрузке данных: {ex.Message}");
            }
        }
    }
}
