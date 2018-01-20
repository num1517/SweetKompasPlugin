using System;

namespace SweetKompasPlugin.Model.Exceptions
{
    public class CandyLengthException : ApplicationException
    {
        public CandyLengthException(string message) : base(message)
        {
        }
    }
}
