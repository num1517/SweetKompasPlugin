using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using SweetKompasPlugin.Model.Exceptions;
using Kompas6Constants3D;

namespace SweetKompasPlugin.Model
{
    class Rect : CandyBase
    {
        private double _width;
        private double _height;
        private double _length;

        public Rect(double width, double height, double length)
        {
            Width = width;
            Height = height;
            Length = length;
        }

        /// <summary>
        /// Ширина прямоугольной конфеты
        /// </summary>
        public override double Width
        {
            get
            {
                return _width;
            }

            protected set
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
        public override double Height
        {
            get
            {
                return _height;
            }

            protected set
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

        public override void Build(ksPart part, ksEntity planeFormSurface, 
            CandySettings candySettings, double formTotalLength, double formTotalWidth)
        {
            // Создание и настройка эскиза на поверхности формы (смещенной плоскости)

            ksEntity formSurfaceSketch = part.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition formSurfaceSketchDefinition = formSurfaceSketch.GetDefinition();
            formSurfaceSketchDefinition.SetPlane(planeFormSurface);
            formSurfaceSketch.Create();

            // Входим в режим редактирования эскиза
            ksDocument2D formSurfaceDocument2D = formSurfaceSketchDefinition.BeginEdit();

            // Расчитаем положение первой конфеты
            // Положение других конфет расчитаем путем сдвига первой

            double[] rectCandyXPoints = new double[] { 0, 0, 0, 0, 0 };
            double[] rectCandyYPoints = new double[] { 0, 0, 0, 0, 0 };

            InitRectCandyPoints(ref rectCandyXPoints, ref rectCandyYPoints,
                formTotalLength, formTotalWidth, candySettings);

            // Рисуем  прямоугольные конфеты
            for (int i = 0; i < candySettings.CandyCount / 2; ++i)
            {
                for (int j = 0; j < 2; ++j)
                {
                    DrawRect(rectCandyXPoints, rectCandyYPoints, formSurfaceDocument2D);

                    rectCandyYPoints = GetShiftedArray(rectCandyYPoints,
                        Length + candySettings.FormDepthByWidth);
                }
                rectCandyYPoints = GetShiftedArray(rectCandyYPoints,
                    -2 * (Length + candySettings.FormDepthByWidth));
                rectCandyXPoints = GetShiftedArray(rectCandyXPoints,
                    Width + candySettings.FormDepthByLength);
            }

            // Выходим из режима редактирования эскиза
            formSurfaceSketchDefinition.EndEdit();

            // Вырезаем прямоугольные конфетки ^_^
            CutExtrude(part, formSurfaceSketch, Height);
        }

        /// <summary>
        /// Расчет точек прямоугольной конфеты
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="formTotalLength"></param>
        /// <param name="formTotalWidth"></param>
        /// <param name="candySettings"></param>
        private void InitRectCandyPoints(ref double[] X, ref double[] Y,
            double formTotalLength, double formTotalWidth,
            CandySettings candySettings)
        {
            X = new double[]
                {
                (-formTotalLength / 2) + candySettings.FormDepthByLength,
                (-formTotalLength / 2) + candySettings.FormDepthByLength,
                (-formTotalLength / 2) + candySettings.FormDepthByLength
                    + Width,
                (-formTotalLength / 2) + candySettings.FormDepthByLength
                    + Width,
                (-formTotalLength / 2) + candySettings.FormDepthByLength
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
    }
}
