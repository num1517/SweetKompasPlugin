using SweetKompasPlugin.Model.Exceptions;

namespace SweetKompasPlugin.Model
{
    class SphereCandy : ICandy
    {
        private double _r;

        public SphereCandy(double r)
        {
            R = r;
        }

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

        public double Width
        {
            get
            {
                return 2*R;
            }
        }

        public double Height
        {
            get
            {
                return R;
            }
        }

        public double Length
        {
            get
            {
                return 2*R;
            }
        }
    }
}
