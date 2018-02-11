using SweetKompasPlugin.Model.Exceptions;

namespace SweetKompasPlugin.Model
{
    /// <summary>
    /// Прямоугольная конфета
    /// </summary>
    public class RectCandy : ICandy
    {
        private double _width;
        private double _height;
        private double _length;

        /// <summary>
        /// Конструктор прямоугольной конфеты
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="length"></param>
        public RectCandy(double width, double height, double length)
        {
            Width = width;
            Height = height;
            Length = length;
        }

        /// <summary>
        /// Ширина прямоугольной конфеты
        /// </summary>
        public double Width
        {
            get
            {
                return _width;
            }

            private set
            {
                if (!Validator.IsValidDouble(value))
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
                _width = value;
            }
        }

        /// <summary>
        /// Высота прямоугольной конфеты
        /// </summary>
        public double Height
        {
            get
            {
                return _height;
            }

            private set
            {
                if (!Validator.IsValidDouble(value))
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
                _height = value;
            }
        }

        /// <summary>
        /// Длина прямоугольной конфеты
        /// </summary>
        public double Length
        {
            get
            {
                return _length;
            }

            private set
            {
                if (!Validator.IsValidDouble(value))
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
                _length = value;
            }
        }
    }
}
