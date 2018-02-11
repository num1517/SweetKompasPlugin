using System;

namespace SweetKompasPlugin.Model.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает в случае, если параметр "толщина формы по длине" задан неправильно.
    /// </summary>
    public class FormDepthByLengthException : ApplicationException
    {
        /// <summary>
        /// Конструктор исключения
        /// </summary>
        /// <param name="message"></param>
        public FormDepthByLengthException(string message) : base(message)
        {
        }
    }
}
