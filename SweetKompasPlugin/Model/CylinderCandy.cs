using SweetKompasPlugin.Model.Exceptions;

namespace SweetKompasPlugin.Model
{
    /// <summary>
    /// Цилиндрическая конфета
    /// </summary>
    public class CylinderCandy : ICandy
    {
        private double _r;
        private double _length;

        /// <summary>
        /// Конструктор цилиндрической конфеты
        /// </summary>
        /// <param name="r"></param>
        /// <param name="length"></param>
        public CylinderCandy(double r, double length)
        {
            R = r;
            Length = length;
        }

        /// <summary>
        /// Ширина целиндрической конфеты
        /// </summary>
        public double Width
        {
            get
            {
                return 2*R;
            }
        }

        /// <summary>
        /// Высота цилиндрической конфеты
        /// </summary>
        public double Height
        {
            get
            {
                return R;
            }
        }

        /// <summary>
        /// Радиус целиндрической конфеты
        /// </summary>
        public double R
        {
            get
            {
                return _r;
            }

            private set
            {
                if (!Validator.IsValidDouble(value))
                {
                    throw new CandyRadiusException(
                        "Заданный радиус конфеты - не вещественное число.");
                }
                if (!(value >= 10))
                {
                    throw new CandyRadiusException(
                        "Радиус конфеты не может быть меньше 10 мм.");
                }
                if (!(value <= 25))
                {
                    throw new CandyRadiusException(
                        "Радиус конфеты не может быть больше 25 мм.");
                }
                _r = value;
            }
        }

        /// <summary>
        /// Длина целиндрической конфеты
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
