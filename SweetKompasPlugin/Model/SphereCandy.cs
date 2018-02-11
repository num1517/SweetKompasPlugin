using SweetKompasPlugin.Model.Exceptions;

namespace SweetKompasPlugin.Model
{
    /// <summary>
    /// Сферическая конфеты
    /// </summary>
    public class SphereCandy : ICandy
    {
        private double _r;

        /// <summary>
        /// Конструктор сферической конфеты
        /// </summary>
        /// <param name="r"></param>
        public SphereCandy(double r)
        {
            R = r;
        }

        /// <summary>
        /// Радиус сферической конфеты
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
        /// Ширина сферической конфеты
        /// </summary>
        public double Width
        {
            get
            {
                return 2*R;
            }
        }


        /// <summary>
        /// Высота сферической конфеты
        /// </summary>
        public double Height
        {
            get
            {
                return R;
            }
        }

        /// <summary>
        /// Длина сферической конфеты
        /// </summary>
        public double Length
        {
            get
            {
                return 2*R;
            }
        }
    }
}
