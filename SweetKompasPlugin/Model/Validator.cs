using System;

namespace SweetKompasPlugin.Model
{
    /// <summary>
    /// Валидация параметров
    /// true - валидация пройдена
    /// </summary>
    class Validator
    {
        /// <summary>
        /// Валидация целого числа
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static public bool IsValidInt(Int32 value)
        {
            if (value < Int32.MinValue
                || value > Int32.MaxValue)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Валидация числа двойной точности с плавающей запятой
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
