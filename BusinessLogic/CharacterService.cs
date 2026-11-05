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
        private readonly IRepository<Character> _repository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository">Репозитория</param>
        public CharacterService(IRepository<Character> repository)
        {
            _repository = repository;
            SeedIfEmpty();
        }

        /// <summary>
        /// Заполняет список, но только если он пуст
        /// </summary>
        private void SeedIfEmpty()
        {
            if (_repository.ReadAll().Any()) return;

            AddCharacter("Бримис", "Берёза", 46);
            AddCharacter("Аэрен", "Сосна", 66);
            AddCharacter("Данудор", "Тополь", 80);
            AddCharacter("Гвинрил", "Дуб", 102);
            AddCharacter("Элалов", "Клён", 92);
            AddCharacter("Каэрра", "Берёза", 76);
            AddCharacter("Финтин", "Дуб", 70);
            AddCharacter("Дэнлоу", "Сосна", 115);
            AddCharacter("Эладор", "Ель", 38);
            AddCharacter("Циркис", "Тополь", 59);
        }

        #region ICharacterRead
        public Character? GetCharacterById(int id) => _repository.ReadById(id);

        public IEnumerable<Character> GetAllCharacters() => _repository.ReadAll();
        #endregion

        #region ICharacterWrite
        public bool AddCharacter(string name, string genus, int age)
        {
            if (!Validation.ValidateCharacter(name, genus, age, out _))
                return false;

            _repository.Add(new Character(0, name, genus, age));
            return true;
        }

        public bool DeleteCharacter(int id)
        {
            if (_repository.ReadById(id) == null)
                return false;

            _repository.Delete(id);
            return true;
        }

        public bool UpdateCharacter(int id, string name, string genus, int age)
        {
            var character = _repository.ReadById(id);
            if (character == null)
                return false;

            if (!Validation.ValidateCharacter(name, genus, age, out _))
                return false;

            character.Name = name;
            character.Genus = genus;
            character.Age = age;
            _repository.Update(character);
            return true;
        }
        #endregion

        #region ICharacterFilter
        public IEnumerable<Character> FilterByMinAge(IEnumerable<Character> characters, int minAge)
        {
            return characters.Where(c => c.Age >= minAge);
        }
        #endregion

        #region ICharacterSort
        public IEnumerable<Character> Sort<T>(IEnumerable<Character> characters,
            Func<Character, T> keySelector)
            => characters.OrderBy(keySelector);
        #endregion
    }
}
