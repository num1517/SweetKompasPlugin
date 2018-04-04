using System;

namespace SweetKompasPlugin.Model.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает в случае, если параметр 
    /// "толщина формы по ширине" задан неправильно.
    /// </summary>
    public class FormDepthByWidthException : ApplicationException
    {
        /// <summary>
        /// Конструктор исключения
        /// </summary>
        /// <param name="message">Подробный текст исключения</param>
        public FormDepthByWidthException(string message) : base(message)
        {
        }
    }
}
