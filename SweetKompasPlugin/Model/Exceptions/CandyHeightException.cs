using System;

namespace SweetKompasPlugin.Model.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает в случае, если параметр 
    /// "высота конфеты" задан неправильно.
    /// </summary>
    public class CandyHeightException : ApplicationException
    {
        /// <summary>
        /// Конструктор исключения
        /// </summary>
        /// <param name="message">Подробный текст исключения</param>
        public CandyHeightException(string message) : base(message)
        {
        }
    }
}
