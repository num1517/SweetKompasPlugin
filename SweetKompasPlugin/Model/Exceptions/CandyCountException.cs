using System;

namespace SweetKompasPlugin.Model.Exceptions
{
    public class CandyCountException : ApplicationException
    {
        public CandyCountException(string message) : base(message)
        {
        }
    }
}
