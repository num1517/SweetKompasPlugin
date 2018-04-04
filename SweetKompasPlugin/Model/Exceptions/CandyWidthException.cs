using System;

namespace SweetKompasPlugin.Model.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает в случае, если параметр 
    /// "ширина конфеты" задан неправильно.
    /// </summary>
    public class CandyWidthException : ApplicationException
    {
        /// <summary>
        /// Конструктор исключения
        /// </summary>
        /// <param name="message">Подробный текст исключения</param>
        public CandyWidthException(string message) : base(message)
        {
        }
    }
}
