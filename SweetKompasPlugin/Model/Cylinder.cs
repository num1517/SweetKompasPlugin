using SweetKompasPlugin.Model.Exceptions;

using Kompas6API5;
using Kompas6Constants3D;

namespace SweetKompasPlugin.Model
{
    /// <summary>
    /// Цилиндрическая конфета
    /// </summary>
    public class Cylinder : CandyBase
    {
        private double _radius;
        private double _length;

        /// <summary>
        /// Конструктор цилиндрической конфеты
        /// </summary>
        /// <param name="radius">Радиус конфеты</param>
        /// <param name="length">Длина конфеты</param>
        public Cylinder(double radius, double length)
        {
            Radius = radius;
            Length = length;
        }

        /// <summary>
        /// Построение выреза цилиндрической конфеты
        /// </summary>
        /// <param name="part">Компонент сборки</param>
        /// <param name="planeFormSurface">Плоскость поверхности формы</param>
        /// <param name="candySettings">Параметры конфетной формы</param>
        /// <param name="formTotalLength">Общая длина конфетной формы</param>
        /// <param name="formTotalWidth">Общая ширина конфетной формы</param>
        public override void Build(ksPart part, ksEntity planeFormSurface, 
            CandySettings candySettings, double formTotalLength, 
            double formTotalWidth)
        {
            double[] cylinderCandyXPoints = new double[] { 0, 0, 0, 0, 0 };
            double[] cylinderCandyYPoints = new double[] { 0, 0, 0, 0, 0 };

            InitCylinderCandyPoints(ref cylinderCandyXPoints, 
                ref cylinderCandyYPoints, formTotalLength, formTotalWidth, 
                candySettings);

            for (int i = 0; i < candySettings.CandyCount / 2; ++i)
            {
                for (int j = 0; j < 2; ++j)
                {
                    // Создание и настройка эскиза на 
                    // поверхности формы (смещенной плоскости)

                    ksEntity formSurfaceSketch = 
                        part.NewEntity((short)Obj3dType.o3d_sketch);
                    ksSketchDefinition formSurfaceSketchDefinition = 
                        formSurfaceSketch.GetDefinition();
                    formSurfaceSketchDefinition.SetPlane(planeFormSurface);
                    formSurfaceSketch.Create();

                    // Входим в режим редактирования эскиза
                    ksDocument2D formSurfaceDocument2D = 
                        (ksDocument2D)formSurfaceSketchDefinition.BeginEdit();

                    DrawRect(cylinderCandyXPoints, cylinderCandyYPoints, 
                        formSurfaceDocument2D, 0);

                    // Выходим из режима редактирования эскиза
                    formSurfaceSketchDefinition.EndEdit();

                    CutRotated(part, formSurfaceSketch);

                    cylinderCandyYPoints = 
                        GetShiftedArray(cylinderCandyYPoints, 
                        Length + candySettings.FormDepthByWidth);
                }
                cylinderCandyYPoints = 
                    GetShiftedArray(cylinderCandyYPoints,
                    -2 * (Length + candySettings.FormDepthByWidth));
                cylinderCandyXPoints = 
                    GetShiftedArray(cylinderCandyXPoints, 
                    Width + candySettings.FormDepthByLength);
            }
        }

        /// <summary>
        /// Расчет точек цилиндрической конфеты
        /// </summary>
        /// <param name="X">Массив x координат точек конфеты</param>
        /// <param name="Y">Массив y координат точек конфеты</param>
        /// <param name="formTotalLength">Общая длина конфетной формы</param>
        /// <param name="formTotalWidth">Общая ширина конфетной формы</param>
        /// <param name="candySettings">Параметры конфетной формы</param>
        private void InitCylinderCandyPoints(ref double[] X, ref double[] Y,
            double formTotalLength, double formTotalWidth,
            CandySettings candySettings)
        {
            X = new double[]
                {
                (-formTotalLength / 2) + candySettings.FormDepthByLength 
                    + Width / 2,
                (-formTotalLength / 2) + candySettings.FormDepthByLength 
                    + Width / 2,
                (-formTotalLength / 2) + candySettings.FormDepthByLength
                    + Width,
                (-formTotalLength / 2) + candySettings.FormDepthByLength
                    + Width,
                (-formTotalLength / 2) + candySettings.FormDepthByLength 
                    + Width / 2
                };
            Y = new double[]
            {
                (-formTotalWidth / 2) + candySettings.FormDepthByWidth,
                (-formTotalWidth / 2) + candySettings.FormDepthByWidth
                    + Length,
                (-formTotalWidth / 2) + candySettings.FormDepthByWidth
                    + Length,
                (-formTotalWidth / 2) + candySettings.FormDepthByWidth,
                (-formTotalWidth / 2) + candySettings.FormDepthByWidth
            };
        }

        /// <summary>
        /// Ширина цилиндрической конфеты
        /// </summary>
        public override double Width
        {
            get
            {
                return 2 * Radius;
            }
            protected set
            {

            }
        }

        /// <summary>
        /// Высота цилиндрической конфеты
        /// </summary>
        public override double Height
        {
            get
            {
                return Radius;
            }
            protected set
            {

            }
        }

        /// <summary>
        /// Радиус цилиндрической конфеты
        /// </summary>
        public double Radius
        {
            get
            {
                return _radius;
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
                _radius = value;
            }
        }

        /// <summary>
        /// Длина цилиндрической конфеты
        /// </summary>
        public override double Length
        {
            get
            {
                return _length;
            }

            protected set
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
