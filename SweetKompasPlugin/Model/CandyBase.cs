using Kompas6API5;
using Kompas6Constants3D;

namespace SweetKompasPlugin.Model
{
    /// <summary>
    /// Абстрактный класс конфеты
    /// </summary>
    abstract public class CandyBase
    {
        /// <summary>
        /// Построение выреза конфеты
        /// </summary>
        /// <param name="part">Компонент сборки</param>
        /// <param name="planeFormSurface">Плоскость поверхности формы</param>
        /// <param name="candySettings">Параметры конфетной формы</param>
        /// <param name="formTotalLength">Общая длина конфетной формы</param>
        /// <param name="formTotalWidth">Общая ширина конфетной формы</param>
        public abstract void Build(ksPart part, ksEntity planeFormSurface, 
            CandySettings candySettings, double formTotalLength, 
            double formTotalWidth);

        /// <summary>
        /// Рисование в компасе квадрата.
        /// axisline = номер линии которую нужно нарисовать осевой
        /// </summary>
        /// <param name="x">Массив x координат точек</param>
        /// <param name="y">Массив y координат точек</param>
        /// <param name="doc2d">Чертеж</param>
        /// <param name="axisline">Номер осевой линии</param>
        public static void DrawRect(double[] x, double[] y, 
            ksDocument2D doc2d, int axisline = -1)
        {
            int lineStyle = 1;
            for (int k = 0; k < 4; ++k)
            {
                if (k == axisline)
                {
                    // 3 = осевая линия
                    lineStyle = 3;
                }
                doc2d.ksLineSeg(x[k], y[k],
                    x[k + 1], y[k + 1], lineStyle);
                lineStyle = 1;
            }
        }

        /// <summary>
        /// Сдвиг массива.
        /// Увеличивает все параметры массива на число.
        /// </summary>
        /// <param name="array">Исходный массив</param>
        /// <param name="shift">Величина сдвига</param>
        /// <returns>Сдвинутый массив</returns>
        protected double[] GetShiftedArray(double[] array, double shift)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] += shift;
            }
            return array;
        }

        /// <summary>
        /// Вырез вращением на 360 градусов.
        /// Эскиз обязательно должен иметь одну осевую линию
        /// </summary>
        /// <param name="part">Компонент сборки</param>
        /// <param name="sketch">Вырезаемый эскиз</param>
        protected void CutRotated(ksPart part, ksEntity sketch)
        {
            ksEntity rotate = 
                (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutRotated);
            ksCutRotatedDefinition rotDef = 
                (ksCutRotatedDefinition)rotate.GetDefinition();
            rotDef.directionType = (short)Direction_Type.dtNormal;
            rotDef.cut = true;
            rotDef.SetSideParam(true, 360);
            rotDef.toroidShapeType = false;
            rotDef.SetSketch(sketch);
            rotate.Create();
        }

        /// <summary>
        /// Обычный вырез
        /// </summary>
        /// <param name="part">Компонент сборки</param>
        /// <param name="sketch">Вырезаемый эскиз</param>
        /// <param name="depth">Глубина выреза</param>
        protected void CutExtrude(ksPart part, ksEntity sketch, 
            double depth)
        {
            ksEntity cutExtrude = 
                part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition cutextrDefinition = 
                cutExtrude.GetDefinition();
            cutextrDefinition.directionType = 
                (short)Direction_Type.dtNormal;
            cutextrDefinition.SetSketch(sketch);
            ksExtrusionParam cutExtrudeParam = 
                cutextrDefinition.ExtrusionParam();
            cutExtrudeParam.depthNormal = depth;
            cutExtrude.Create();
        }

        /// <summary>
        /// Ширина конфеты
        /// </summary>
        public abstract double Width
        {
            get; protected set;
        }

        /// <summary>
        /// Высота конфеты
        /// </summary>
        public abstract double Height
        {
            get; protected set;
        }

        /// <summary>
        /// Длина конфеты
        /// </summary>
        public abstract double Length
        {
            get; protected set;
        }
    }
}
