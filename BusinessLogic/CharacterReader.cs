using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Класс чтение персонажа
    /// </summary>
    public class CharacterReader : ICharacterRead
    {
        private readonly IReadRepository<Character> _readRepository;

        public CharacterReader(IReadRepository<Character> readRepository)
        {
            _readRepository = readRepository;
        }

        public Character? GetCharacterById(int id) => _readRepository.ReadById(id);
        public IEnumerable<Character> GetAllCharacters() => _readRepository.ReadAll();
    }
}
