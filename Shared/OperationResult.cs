namespace Shared
{
    /// <summary>
    /// Результат операции (добавление/изменение/удаление).
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// Успешность операции.
        /// </summary>
        public bool IsSuccess { get; }
        /// <summary>
        /// Текст сообщения для пользователя.
        /// </summary>
        public string Message { get; }
        /// <summary>
        /// Разрешение закрыть активную подформу.
        /// Учитывается только в WinForms; в консоли игнорируется.
        /// </summary>
        public bool CanCloseSubform { get; }

        public OperationResult(bool isSuccess, string message, bool canCloseSubform = false)
        {
            IsSuccess = isSuccess;
            Message = message;
            CanCloseSubform = canCloseSubform;
        }
    }
}
