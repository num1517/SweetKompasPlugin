using System;

namespace SweetKompasPlugin.Model.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает в случае, если параметр "толщина формы по высоте" задан неправильно.
    /// </summary>
    public class FormDepthByHeightException : ApplicationException
    {
        /// <summary>
        /// Конструктор исключения
        /// </summary>
        /// <param name="message"></param>
        public FormDepthByHeightException(string message) : base(message)
        {
        }
    }
}
