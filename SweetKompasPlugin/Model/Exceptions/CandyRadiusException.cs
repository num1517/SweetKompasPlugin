using System;

namespace SweetKompasPlugin.Model.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает в случае, если параметр 
    /// "радиус конфеты" задан неправильно.
    /// </summary>
    public class CandyRadiusException : ApplicationException
    {
        /// <summary>
        /// Конструктор исключения
        /// </summary>
        /// <param name="message">Подробный текст исключения</param>
        public CandyRadiusException(string message) : base(message)
        {
        }
    }
}
