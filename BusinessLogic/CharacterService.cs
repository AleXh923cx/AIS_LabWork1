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
        private readonly ICharacterFilter _filter;
        private readonly ICharacterSort _sorter;
        
        public CharacterService(
            ICharacterRead reader,
            ICharacterWrite writer,
            ICharacterFilter filter,
            ICharacterSort sorter
        )
        {
            _reader = reader;
            _writer = writer;
            _filter = filter;
            _sorter = sorter;
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
        {
            IEnumerable<Character> chars = _reader.GetAllCharacters();

            if (minAge.HasValue)
                chars = _filter.FilterByMinAge(chars, minAge.Value);

            chars = _sorter.Sort(chars, sortKey);

            return chars.ToList();
        }

        /// <summary>
        /// Заполняет список, но только если он пуст
        /// </summary>
        // private void SeedIfEmpty()
        // {
        //     if (_repository.ReadAll().Any()) return;
        // 
        //     AddCharacter("Бримис", "Берёза", 46);
        //     AddCharacter("Аэрен", "Сосна", 66);
        //     AddCharacter("Данудор", "Тополь", 80);
        //     AddCharacter("Гвинрил", "Дуб", 102);
        //     AddCharacter("Элалов", "Клён", 92);
        //     AddCharacter("Каэрра", "Берёза", 76);
        //     AddCharacter("Финтин", "Дуб", 70);
        //     AddCharacter("Дэнлоу", "Сосна", 115);
        //     AddCharacter("Эладор", "Ель", 38);
        //     AddCharacter("Циркис", "Тополь", 59);
        // }
    }
}
