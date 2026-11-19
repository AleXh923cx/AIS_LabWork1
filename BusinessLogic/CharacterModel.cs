using Model;
using Shared;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class CharacterModel : IModel
    {
        private readonly ICharacterService _facade;

        public event EventHandler<List<CharacterDto>>? CharactersLoaded;
        public event EventHandler<string>? ErrorOccurred;

        public CharacterModel(ICharacterService facade)
        {
            _facade = facade;
        }

        public void Add(CharacterDto character)
        {
            _facade.AddCharacter(
                character.Name, 
                character.Genus, 
                character.Age
            );
        }

        public void Delete(int id)
        {
            _facade.DeleteCharacter(id);
        }

        public void Update(CharacterDto character)
        {
            _facade.UpdateCharacter(
                character.Id,
                character.Name,
                character.Genus,
                character.Age
            );
        }

        public void Load(SortOption sortBy, int? minAge)
        {
            try
            {
                Func<Character, object> sortKey = sortBy switch
                {
                    SortOption.ById => c => c.Id,
                    SortOption.ByGenus => c => c.Genus,
                    _ => c => c.Id // на всякий случай
                };

                var characters = _facade.GetProcessedCharacters(sortKey, minAge);

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
