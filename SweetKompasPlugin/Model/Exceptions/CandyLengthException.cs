using System;

namespace SweetKompasPlugin.Model.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает в случае, если параметр "длина конфеты" задан неправильно.
    /// </summary>
    public class CandyLengthException : ApplicationException
    {
        /// <summary>
        /// Конструктор исключения
        /// </summary>
        /// <param name="message"></param>
        public CandyLengthException(string message) : base(message)
        {
        }
    }
}
