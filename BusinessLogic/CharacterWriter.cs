using DataAccessLayer;
using Shared;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Класс изменения персонажа
    /// </summary>
    public class CharacterWriter : ICharacterWrite
    {
        private readonly IReadRepository<Character> _readRepository;
        private readonly IWriteRepository<Character> _writeRepository;

        public CharacterWriter(IWriteRepository<Character> writer, IReadRepository<Character> reader)
        {
            _readRepository = reader;
            _writeRepository = writer;
        }

        public (bool Success, string ErrorMessage) AddCharacter(string name, string genus, int age)
        {
            if (!Validation.ValidateCharacter(name, genus, age, out string error))
                return (false, error);

            _writeRepository.Add(new Character(0, name, genus, age));
            return (true, string.Empty);
        }

        public (bool Success, string ErrorMessage) DeleteCharacter(int id)
        {
            if (_readRepository.ReadById(id) == null)
                return (false, $"Персонаж с номером ИД {id} не найден.");

            _writeRepository.Delete(id);
            return (true, string.Empty);
        }

        public (bool Success, string ErrorMessage) UpdateCharacter(int id, string name, string genus, int age)
        {
            var character = _readRepository.ReadById(id);
            if (character == null)
                return (false, $"Персонаж с номером ИД {id} не найден.");

            if (!Validation.ValidateCharacter(name, genus, age, out string error))
                return (false, error);

            character.Name = name;
            character.Genus = genus;
            character.Age = age;
            _writeRepository.Update(character);
            return (true, string.Empty);
        }
    }
}
