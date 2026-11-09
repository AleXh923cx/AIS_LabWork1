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
        /// Добавляет персонажа
        /// </summary>
        /// <param name="name">Имя персонажа</param>
        /// <param name="genus">Вид персонажа</param>
        /// <param name="age">Возраст персонажа</param>
        /// <returns>Успешность операции</returns>
        bool AddCharacter(string name, string genus, int age);
        /// <summary>
        /// Удаляет персонажа
        /// </summary>
        /// <param name="id">Идентификатор персонажа</param>
        /// <returns>Успешность операции</returns>
        bool DeleteCharacter(int id);
        /// <summary>
        /// Изменяет персонажа
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
        private readonly IRepository<Character> _repository;

        public CharacterWriter(IRepository<Character> repository)
        {
            _repository = repository;
        }

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
    }
}
