using System;

namespace SweetKompasPlugin.Model
{
    class Validator
    {
        static public bool IsValidInt(Int32 value)
        {
            if (value < Int32.MinValue
                || value > Int32.MaxValue)
            {
                return false;
            }
            return true;
        }

        static public bool IsValidDouble(double value)
        {
            if (value < Double.MinValue
                || value > Double.MaxValue
                || Double.IsInfinity(value)
                || Double.IsNaN(value)
            )
            {
                return false;
            }

            return true;
        }
    }
}
