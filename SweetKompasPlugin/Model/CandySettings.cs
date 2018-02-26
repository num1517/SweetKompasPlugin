using SweetKompasPlugin.Model.Exceptions;

namespace SweetKompasPlugin.Model
{
    /// <summary>
    /// Конфетная форма
    /// </summary>
    public class CandySettings
    {
        private int _candyCount;
        private double _formDepthByLength;
        private double _formDepthByWidth;
        private double _formDepthByHeight;

        /// <summary>
        /// Конструктор конфетной формы
        /// </summary>
        /// <param name="candyCount"></param>
        /// <param name="formDepthByLength"></param>
        /// <param name="formDepthByWidth"></param>
        /// <param name="formDepthByHeight"></param>
        public CandySettings(int candyCount, double formDepthByLength, double formDepthByWidth, double formDepthByHeight)
        {
            CandyCount = candyCount;
            FormDepthByLength = formDepthByLength;
            FormDepthByWidth = formDepthByWidth;
            FormDepthByHeight = formDepthByHeight;
        }
        
        /// <summary>
        /// Количество конфет на форме
        /// </summary>
        public int CandyCount
        {
            get
            {
                return _candyCount;
            }

            private set
            {
                if (!Validator.IsValidInt(value))
                {
                    throw new CandyCountException(
                        "Заданное количество конфет - не целое число.");
                }
                if (!(value % 2 == 0))
                {
                    throw new CandyCountException(
                        "Количество конфет должно быть четным.");
                }
                if (!(value >= 8))
                {
                    throw new CandyCountException(
                        "Количество конфет не может быть меньше 8.");
                }
                if (!(value <= 20))
                {
                    throw new CandyCountException(
                        "Количество конфет не может быть больше 20.");
                }
                _candyCount = value;
            }
        }

        /// <summary>
        /// Толщина формы по длине
        /// </summary>
        public double FormDepthByLength
        {
            get
            {
                return _formDepthByLength;
            }

            private set
            {
                if (!Validator.IsValidDouble(value))
                {
                    throw new FormDepthByLengthException(
                        "Заданная толщина формы по длине - не вещественное число.");
                }
                if (!(value >= 3))
                {
                    throw new FormDepthByLengthException(
                        "Толщина формы по длине не может быть меньше 3 мм.");
                }
                if (!(value <= 5))
                {
                    throw new FormDepthByLengthException(
                        "Толщина формы по длине не может быть больше 5 мм.");
                }
                _formDepthByLength = value;
            }
        }

        /// <summary>
        /// Толщина формы по ширине
        /// </summary>
        public double FormDepthByWidth
        {
            get
            {
                return _formDepthByWidth;
            }

            private set
            {
                if (!Validator.IsValidDouble(value))
                {
                    throw new FormDepthByWidthException(
                        "Заданная толщина формы по ширине - не вещественное число.");
                }
                if (!(value >= 3))
                {
                    throw new FormDepthByWidthException(
                        "Толщина формы по ширине не может быть меньше 3 мм.");
                }
                if (!(value <= 5))
                {
                    throw new FormDepthByWidthException(
                        "Толщина формы по ширине не может быть больше 5 мм.");
                }
                _formDepthByWidth = value;
            }
        }

        /// <summary>
        /// Толщина формы по высоте
        /// </summary>
        public double FormDepthByHeight
        {
            get
            {
                return _formDepthByHeight;
            }

            private set
            {
                if (!Validator.IsValidDouble(value))
                {
                    throw new FormDepthByHeightException(
                        "Заданная толщина формы по высоте - не вещественное число.");
                }
                if (!(value >= 3))
                {
                    throw new FormDepthByHeightException(
                        "Толщина формы по высоте не может быть меньше 3 мм.");
                }
                if (!(value <= 5))
                {
                    throw new FormDepthByHeightException(
                        "Толщина формы по высоте не может быть больше 5 мм.");
                }
                _formDepthByHeight = value;
            }
        }
    }
}
