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
}
