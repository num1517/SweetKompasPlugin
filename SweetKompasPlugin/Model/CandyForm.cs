using System;

using SweetKompasPlugin.Model.Exceptions;

namespace SweetKompasPlugin.Model
{
    public class CandyForm
    {
        private int _candyCount;
        private double _candyLength;
        private double _candyWidth;
        private double _candyHeight;
        private double _formDepthByLength;
        private double _formDepthByWidth;
        private double _formDepthByHeight;

        public CandyForm(int candyCount, double candyLength, 
            double candyWidth, double candyHeight,
            double formDepthByLength, double formDepthByWidth,
            double formDepthByHeight)
        {
            CandyCount = candyCount;
            CandyLength = candyLength;
            CandyWidth = candyWidth;
            CandyHeight = candyHeight;
            FormDepthByLength = formDepthByLength;
            FormDepthByWidth = formDepthByWidth;
            FormDepthByHeight = formDepthByHeight;
        }

        public int CandyCount
        {
            get
            {
                return _candyCount;
            }

            private set
            {
                if (!IsValidInt(value))
                {
                    throw new CandyCountException(
                        "Заданное количество конфет - не целое число.");
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

        public double CandyLength
        {
            get
            {
                return _candyLength;
            }

            private set
            {
                if (!IsValidDouble(value))
                {
                    throw new CandyLengthException(
                        "Заданная длина конфеты - не вещественное число.");
                }
                if (!(value >= 20))
                {
                    throw new CandyLengthException(
                        "Длина конфеты не может быть меньше 20 мм.");
                }
                if (!(value <= 50))
                {
                    throw new CandyLengthException(
                        "Длина конфеты не может быть больше 50 мм.");
                }
                _candyLength = value;
            }
        }

        public double CandyWidth
        {
            get
            {
                return _candyWidth;
            }

            private set
            {
                if (!IsValidDouble(value))
                {
                    throw new CandyWidthException(
                        "Заданная ширина конфеты - не вещественное число.");
                }
                if (!(value >= 20))
                {
                    throw new CandyWidthException(
                        "Ширина конфеты не может быть меньше 20 мм.");
                }
                if (!(value <= 50))
                {
                    throw new CandyWidthException(
                        "Ширина конфеты не может быть больше 50 мм.");
                }
                _candyWidth = value;
            }
        }

        public double CandyHeight
        {
            get
            {
                return _candyHeight;
            }

            private set
            {
                if (!IsValidDouble(value))
                {
                    throw new CandyHeightException(
                        "Заданная высота конфеты - не вещественное число.");
                }
                if (!(value >= 15))
                {
                    throw new CandyHeightException(
                        "Высота конфеты не может быть меньше 15 мм.");
                }
                if (!(value <= 30))
                {
                    throw new CandyHeightException(
                        "Высота конфеты не может быть больше 30 мм.");
                }
                _candyHeight = value;
            }
        }

        public double FormDepthByLength
        {
            get
            {
                return _formDepthByLength;
            }

            private set
            {
                if (!IsValidDouble(value))
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

        public double FormDepthByWidth
        {
            get
            {
                return _formDepthByWidth;
            }

            private set
            {
                if (!IsValidDouble(value))
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

        public double FormDepthByHeight
        { get
            {
                return _formDepthByHeight;
            }

            private set
            {
                if (!IsValidDouble(value))
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

        private bool IsValidInt(Int32 value)
        {
            if (value < Int32.MinValue
                || value > Int32.MaxValue)
            {
                return false;
            }
            return true;
        }

        private bool IsValidDouble(double value)
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
