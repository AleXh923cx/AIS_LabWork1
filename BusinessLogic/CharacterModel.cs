using Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLogic
{
    public class CharacterModel : IModel
    {
        private readonly ICharacterService _facade;

        public event EventHandler<List<CharacterDto>>? CharactersLoaded;
        public event EventHandler<string>? ErrorOccurred;

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
                if (!_facade.AddCharacter(
                    character.Name, character.Genus, character.Age
                ))
                {
                    ErrorOccurred?.Invoke(this, "Не удалось добавить персонажа. " +
                        "Проверьте корректность данных.");
                    return;
                }
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
                if (!_facade.DeleteCharacter(id))
                {
                    ErrorOccurred?.Invoke(this, "Не удалось удалить персонажа. " +
                        "Проверьте корректность данных.");
                    return;
                }
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
                if (!_facade.UpdateCharacter(
                    character.Id, character.Name, character.Genus, character.Age
                ))
                {
                    ErrorOccurred?.Invoke(this, "Не удалось изменить персонажа. " +
                        "Проверьте корректность данных.");
                    return;
                }
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
