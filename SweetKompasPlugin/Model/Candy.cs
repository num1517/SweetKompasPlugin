using Kompas6API5;
using Kompas6Constants3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetKompasPlugin.Model
{
    abstract public class Candy
    {
        /// <summary>
        /// Построение конфеты
        /// </summary>
        /// <param name="part"></param>
        /// <param name="planeFormSurface"></param>
        /// <param name="candy"></param>
        /// <param name="candySettings"></param>
        /// <param name="formTotalLength"></param>
        /// <param name="formTotalWidth"></param>
        public abstract void Build(ksPart part, ksEntity planeFormSurface, CandySettings candySettings, double formTotalLength, double formTotalWidth);

        /// <summary>
        /// Рисование в компасе квадрата.
        /// axisline = номер линии которую нужно нарисовать осевой
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="doc2d"></param>
        /// <param name="axisline"></param>
        public static void DrawRect(double[] x, double[] y, ksDocument2D doc2d, int axisline = -1)
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
        /// <param name="array"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
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
        /// <param name="part"></param>
        /// <param name="sketch"></param>
        protected void CutRotated(ksPart part, ksEntity sketch)
        {
            ksEntity rotate = (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutRotated);
            ksCutRotatedDefinition rotDef = (ksCutRotatedDefinition)rotate.GetDefinition();
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
        /// <param name="part"></param>
        /// <param name="sketch"></param>
        /// <param name="depth"></param>
        protected void CutExtrude(ksPart part, ksEntity sketch, double depth)
        {
            ksEntity cutExtrude = part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition cutextrDefinition = cutExtrude.GetDefinition();
            cutextrDefinition.directionType = (short)Direction_Type.dtNormal;
            cutextrDefinition.SetSketch(sketch);
            ksExtrusionParam cutExtrudeParam = cutextrDefinition.ExtrusionParam();
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
