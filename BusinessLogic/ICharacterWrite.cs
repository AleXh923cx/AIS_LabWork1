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
    /// Интерфейс изменении персонажа
    /// </summary>
    public interface ICharacterWrite
    {
        /// <summary>
        /// <b>Добавление персонажа</b>: сначала проверяет доменные данные прежде чем создавать его.
        /// Если персонаж не валиден, то возвращает ошибку.
        /// </summary>
        /// <param name="name">Имя персонажа</param>
        /// <param name="genus">Вид персонажа</param>
        /// <param name="age">Возраст персонажа</param>
        /// <returns>Успешность операции</returns>
        bool AddCharacter(string name, string genus, int age);
        /// <summary>
        /// <b>Удаление персонажа</b>: получает персонажа по ИД.
        /// Если существует персонаж, то удаляется, иначе возвращается <see langword="false"/>, 
        /// если записи с таким № нет.
        /// </summary>
        /// <param name="id">Идентификатор персонажа</param>
        /// <returns>Успешность операции</returns>
        bool DeleteCharacter(int id);
        /// <summary>
        /// <b>Изменение персонажа</b>: сначала ищет персонажа по ИД, потом валидирует его (проверяет), а затем изменяет персонажа.
        /// </summary>
        /// <param name="id">Идентификатор персонажа</param>
        /// <param name="name">Имя персонажа</param>
        /// <param name="genus">Вид персонажа</param>
        /// <param name="age">Возраст персонажа</param>
        /// <returns>Успешность операции</returns>
        bool UpdateCharacter(int id, string name, string genus, int age);
    }

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

        public bool AddCharacter(string name, string genus, int age)
        {
            if (!Validation.ValidateCharacter(name, genus, age, out _))
                return false;

            _writeRepository.Add(new Character(0, name, genus, age));
            return true;
        }

        public bool DeleteCharacter(int id)
        {
            if (_readRepository.ReadById(id) == null)
                return false;

            _writeRepository.Delete(id);
            return true;
        }

        public bool UpdateCharacter(int id, string name, string genus, int age)
        {
            var character = _readRepository.ReadById(id);
            if (character == null)
                return false;

            if (!Validation.ValidateCharacter(name, genus, age, out _))
                return false;

            character.Name = name;
            character.Genus = genus;
            character.Age = age;
            _writeRepository.Update(character);
            return true;
        }
    }
}
