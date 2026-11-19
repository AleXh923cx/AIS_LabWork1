using System;
using System.Collections.Generic;

namespace Shared
{
    public interface IModel
    {
        event EventHandler<List<CharacterDto>> CharactersLoaded;
        event EventHandler<string> ErrorOccurred;

        void Add(CharacterDto character);
        void Delete(int id);
        void Update(CharacterDto character);

        void Load(SortOption sortBy, int? minAge);
    }
}
