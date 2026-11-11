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
    /// Интерфейс чтение персонажа
    /// </summary>
    public interface ICharacterRead
    {
        /// <summary>
        /// Поиск персонажа по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор персонажа</param>
        /// <returns>Персонаж по заданному идентификатору, или <see langword="null"/>,
        /// если записи с указанным id нет.</returns>
        Character? GetCharacterById(int id);
        /// <summary>
        /// Получение всех персонажей
        /// </summary>
        /// <returns>Коллекция всех персонажей</returns>
        IEnumerable<Character> GetAllCharacters();
    }

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
