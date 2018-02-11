using System;

namespace SweetKompasPlugin.Model.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает в случае, если параметр "количество конфет" задан неправильно.
    /// </summary>
    public class CandyCountException : ApplicationException
    {
        /// <summary>
        /// Конструктор исключения
        /// </summary>
        /// <param name="message"></param>
        public CandyCountException(string message) : base(message)
        {
        }
    }
}
