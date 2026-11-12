using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    /// <summary>
    /// Служба персонажа (бизнес-логика), наследующий интерфейса
    /// </summary>
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRead _reader;
        private readonly ICharacterWrite _writer;
        private readonly ICharacterQuery _queryService;
        
        public CharacterService(
            ICharacterRead reader,
            ICharacterWrite writer,
            ICharacterQuery queryService
        )
        {
            _reader = reader;
            _writer = writer;
            _queryService = queryService;
        }

        public bool AddCharacter(string name, string genus, int age)
            => _writer.AddCharacter(name, genus, age);
        public bool DeleteCharacter(int id)
            => _writer.DeleteCharacter(id);
        public bool UpdateCharacter(int id, string name, string genus, int age)
            => _writer.UpdateCharacter(id, name, genus, age);

        public IEnumerable<Character> GetAllCharacters()
            => _reader.GetAllCharacters();
        public Character? GetCharacterById(int id)
            => _reader.GetCharacterById(id);

        public List<Character> GetProcessedCharacters<T>(Func<Character, T> sortKey, int? minAge)
            => _queryService.GetProcessedCharacters<T>(sortKey, minAge);
    }
}
