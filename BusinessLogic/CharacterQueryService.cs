using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Класс службы запросов персонажа
    /// </summary>
    public class CharacterQueryService : ICharacterQueryService
    {
        private readonly ICharacterRead _reader;
        private readonly ICharacterFilter _filter;
        private readonly ICharacterSort _sorter;

        public CharacterQueryService(
            ICharacterRead reader,
            ICharacterFilter filter,
            ICharacterSort sorter)
        {
            _reader = reader;
            _filter = filter;
            _sorter = sorter;
        }

        public List<Character> GetProcessedCharacters<T>(Func<Character, T> sortKey, int? minAge)
        {
            IEnumerable<Character> chars = _reader.GetAllCharacters();

            if (minAge.HasValue)
                chars = _filter.FilterByMinAge(chars, minAge.Value);

            chars = _sorter.Sort(chars, sortKey);

            return chars.ToList();
        }
    }
}
