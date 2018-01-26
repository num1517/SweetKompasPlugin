using SweetKompasPlugin.Model.Exceptions;

namespace SweetKompasPlugin.Model
{
    class RectCandy : ICandy
    {
        private double _width;
        private double _height;
        private double _length;

        public RectCandy(double width, double height, double length)
        {
            Width = width;
            Height = height;
            Length = length;
        }

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
