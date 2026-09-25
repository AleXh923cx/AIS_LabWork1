using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public static class Validation
    {
        /// <summary>
        /// Разбор идентификатор персонажа из строки
        /// </summary>
        /// <param name="input">Ввод</param>
        /// <param name="id">Идентификатор</param>
        /// <param name="error">Сообщение об ошибки</param>
        /// <returns>Валидность идентификатора</returns>
        public static bool TryParseId(string input, out int id, out string error)
        {
            error = null;
            id = 0;

            if (string.IsNullOrEmpty(input))
            {
                error = "№ персонажа не должен быть пустым.";
                return false;
            }

            if (!int.TryParse(input, out id) || id < 1)
            {
                error = "№ персонажа должен быть целым положительным числом.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Разбор возраста из строки
        /// </summary>
        /// <param name="input">Ввод</param>
        /// <param name="age">Возраст</param>
        /// <param name="error">Сообщение об ошибки</param>
        /// <returns>Валидность возраста</returns>
        public static bool TryParseAge(string input, out int age, out string error)
        {
            error = null;
            age = 0;

            if (string.IsNullOrEmpty(input))
            {
                error = "Возраст персонажа не должен быть пустым.";
                return false;
            }

            if (!int.TryParse(input, out age))
            {
                error = "Возраст персонажа должен быть числом.";
                return false;
            }

            if (age < 0)
            {
                error = "Возраст персонажа не может быть отрицательным.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Проверка доменных данных персонажа.
        /// </summary>
        /// <param name="name">Имя персонажа</param>
        /// <param name="genus">Вид персонажа</param>
        /// <param name="age">Возраст персонажа</param>
        /// <param name="error">Сообщение об ошибке</param>
        /// <returns>Валидность персонажа</returns>
        public static bool ValidateCharacter(string name, string genus, int age, out string error)
        {
            error = null;

            if (string.IsNullOrEmpty(name))
            {
                error = "Имя персонажа не должно быть пустым.";
                return false;
            }

            if (string.IsNullOrEmpty(genus))
            {
                error = "Вид персонажа не должен быть пустым.";
                return false;
            }

            if (age < 0)
            {
                error = "Возраст не может быть отрицательным.";
                return false;
            }

            return true;
        }
    }
}
