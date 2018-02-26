using System;

using Kompas6API5;
using Kompas6Constants3D;

namespace SweetKompasPlugin.Model
{
    /// <summary>
    /// Класс для взаимодействия с KOMPAS
    /// </summary>
    public class KompasWrapper
    {
        /// <summary>
        /// Объект KOMPAS API
        /// </summary>
        private KompasObject _kompas = null;

        /// <summary>
        /// Запуск KOMPAS если он не запущен
        /// </summary>
        public void StartKompas()
        {
            if (_kompas == null)
            {
                Type kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompas = (KompasObject)Activator.CreateInstance(kompasType);
            }

            if (_kompas != null)
            {
                bool retry = true;
                short tried = 0;
                while (retry)
                {
                    try
                    {
                        ++tried;
                        _kompas.Visible = true;
                        retry = false;
                    }
                    catch (System.Runtime.InteropServices.COMException)
                    {
                        Type kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                        _kompas = (KompasObject)Activator.CreateInstance(kompasType);
                        if (tried > 3)
                        {
                            retry = false;
                        }
                    }
                }
                _kompas.ActivateControllerAPI();
            }
        }

        /// <summary>
        /// Построить конфетную форму в KOMPAS
        /// </summary>
        /// <param name="candySettings"></param>
        /// <param name="candy"></param>
        public void BuildCandyForm (CandySettings candySettings, ICandy candy)
        {
            if (_kompas == null)
            {
                throw new Exception(
                    "Невозможно построить деталь. Нет связи с КОМПАС 3D.");
            }

            // Рисуем форму

            double formTotalLength = candySettings.FormDepthByLength
                + (candySettings.FormDepthByLength * candySettings.CandyCount / 2)
                + (candy.Width * candySettings.CandyCount / 2);
            double formTotalWidth = (candySettings.FormDepthByWidth * 3)
                + (candy.Length * 2);


            double[] formXPoints = new double[] { 0, 0, 0, 0, 0 };
            double[] formYPoints = new double[] { 0, 0, 0, 0, 0 };

            InitCandySettingsPoints(ref formXPoints, ref formYPoints, formTotalLength, formTotalWidth);

            // Создание документа в компасе

            ksDocument3D document3D = _kompas.Document3D();
            document3D.Create();

            // Получение компонента сборки и базовой плоскости XOY

            ksPart part = document3D.GetPart((short)Part_Type.pTop_Part);
            ksEntity planeXOY = part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);

            // Создание и настройка эскиза

            ksEntity formSketch = part.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDefinition = formSketch.GetDefinition();
            sketchDefinition.SetPlane(planeXOY);
            formSketch.Create();
            
            // Входим в режим редактирования эскиза
            ksDocument2D document2D = sketchDefinition.BeginEdit();

            // Соединение точек формы отрезками
            DrawRect(formXPoints, formYPoints, document2D);

            // Выходим из режима редактирования эскиза
            sketchDefinition.EndEdit();

            // Выдавливание формы
            CandySettingsExtrude(part, formSketch, candy.Height + candySettings.FormDepthByHeight);

            // Создание смещенной плоскости на поверхности формы
            ksEntity planeFormSurface = CreateShiftedPlane(part, planeXOY, 
                (candy.Height + candySettings.FormDepthByHeight) / 2);

            if (candy is RectCandy)
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
                    formTotalLength, formTotalWidth, candySettings, candy);

                // Рисуем  прямоугольные конфеты
                for (int i = 0; i < candySettings.CandyCount / 2; ++i)
                {
                    for (int j = 0; j < 2; ++j)
                    {
                        DrawRect(rectCandyXPoints, rectCandyYPoints, formSurfaceDocument2D);

                        rectCandyYPoints = GetShiftedArray(rectCandyYPoints,
                            candy.Length + candySettings.FormDepthByWidth);
                    }
                    rectCandyYPoints = GetShiftedArray(rectCandyYPoints,
                        -2 * (candy.Length + candySettings.FormDepthByWidth));
                    rectCandyXPoints = GetShiftedArray(rectCandyXPoints,
                        candy.Width + candySettings.FormDepthByLength);
                }

                // Выходим из режима редактирования эскиза
                formSurfaceSketchDefinition.EndEdit();

                // Вырезаем прямоугольные конфетки ^_^
                CutExtrude(part, formSurfaceSketch, candy.Height);
            }

            if (candy is SphereCandy)
            {
                double x = -formTotalLength/2 + candySettings.FormDepthByLength + candy.Height;
                double y = -formTotalWidth/2 + candySettings.FormDepthByWidth + candy.Height;

                for (int i = 0; i < candySettings.CandyCount / 2; ++i)
                {
                    for (int j = 0; j < 2; ++j)
                    {
                        // Создание и настройка эскиза на поверхности формы (смещенной плоскости)

                        ksEntity formSurfaceSketch = part.NewEntity((short)Obj3dType.o3d_sketch);
                        ksSketchDefinition formSurfaceSketchDefinition = formSurfaceSketch.GetDefinition();
                        formSurfaceSketchDefinition.SetPlane(planeFormSurface);
                        formSurfaceSketch.Create();

                        // Входим в режим редактирования эскиза
                        ksDocument2D formSurfaceDocument2D = (ksDocument2D)formSurfaceSketchDefinition.BeginEdit();

                        formSurfaceDocument2D.ksArcByAngle(x, y, candy.Height, 0, 180, 1, 1);
                        formSurfaceDocument2D.ksLineSeg(-candy.Height+x, 0+y, candy.Height+x, 0+y, 3);

                        // Выходим из режима редактирования эскиза
                        formSurfaceSketchDefinition.EndEdit();

                        CutRotated(part, formSurfaceSketch);
                        
                        y += candy.Length + candySettings.FormDepthByWidth;
                    }
                    y -= 2 * (candy.Length + candySettings.FormDepthByWidth);
                    x += candy.Width + candySettings.FormDepthByLength;
                }
            }

            if (candy is CylinderCandy)
            {
                double[] cylinderCandyXPoints = new double[] { 0, 0, 0, 0, 0 };
                double[] cylinderCandyYPoints = new double[] { 0, 0, 0, 0, 0 };

                InitCylinderCandyPoints(ref cylinderCandyXPoints, ref cylinderCandyYPoints, 
                    formTotalLength, formTotalWidth, candySettings, candy);

                for (int i = 0; i < candySettings.CandyCount / 2; ++i)
                {
                    for (int j = 0; j < 2; ++j)
                    {
                        // Создание и настройка эскиза на поверхности формы (смещенной плоскости)

                        ksEntity formSurfaceSketch = part.NewEntity((short)Obj3dType.o3d_sketch);
                        ksSketchDefinition formSurfaceSketchDefinition = formSurfaceSketch.GetDefinition();
                        formSurfaceSketchDefinition.SetPlane(planeFormSurface);
                        formSurfaceSketch.Create();

                        // Входим в режим редактирования эскиза
                        ksDocument2D formSurfaceDocument2D = (ksDocument2D)formSurfaceSketchDefinition.BeginEdit();

                        DrawRect(cylinderCandyXPoints, cylinderCandyYPoints, formSurfaceDocument2D, 0);

                        // Выходим из режима редактирования эскиза
                        formSurfaceSketchDefinition.EndEdit();

                        CutRotated(part, formSurfaceSketch);
                        
                        cylinderCandyYPoints = GetShiftedArray(cylinderCandyYPoints,
                            candy.Length + candySettings.FormDepthByWidth);
                    }
                    cylinderCandyYPoints = GetShiftedArray(cylinderCandyYPoints,
                        -2 * (candy.Length + candySettings.FormDepthByWidth));
                    cylinderCandyXPoints = GetShiftedArray(cylinderCandyXPoints,
                        candy.Width + candySettings.FormDepthByLength);
                }
            }
        }

        /// <summary>
        /// Сдвиг массива.
        /// Увеличивает все параметры массива на число.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        private double[] GetShiftedArray (double[] array, double shift)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] += shift;
            }
            return array;
        }

        /// <summary>
        /// Рисование в компасе квадрата.
        /// axisline = номер линии которую нужно нарисовать осевой
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="doc2d"></param>
        /// <param name="axisline"></param>
        private void DrawRect (double[] x, double[] y, ksDocument2D doc2d, int axisline = -1)
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
        /// Вырез вращением на 360 градусов.
        /// Эскиз обязательно должен иметь одну осевую линию
        /// </summary>
        /// <param name="part"></param>
        /// <param name="sketch"></param>
        private void CutRotated(ksPart part, ksEntity sketch)
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
        /// Выдавливание формы
        /// </summary>
        /// <param name="part"></param>
        /// <param name="formSketch"></param>
        /// <param name="depth"></param>
        private void CandySettingsExtrude(ksPart part, ksEntity formSketch, double depth)
        {
            ksEntity formExtrude = part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            ksBossExtrusionDefinition formExtrudeDefinition = formExtrude.GetDefinition();
            formExtrudeDefinition.directionType = (short)Direction_Type.dtMiddlePlane;
            formExtrudeDefinition.SetSketch(formSketch);
            ksExtrusionParam extrudeParam = formExtrudeDefinition.ExtrusionParam();
            extrudeParam.depthNormal = depth;
            formExtrude.Create();
        }

        /// <summary>
        /// Создание сдвинутой плоскости
        /// </summary>
        /// <param name="part"></param>
        private ksEntity CreateShiftedPlane(ksPart part, ksEntity basePlane, double offset)
        {
            ksEntity planeFormSurface = part.NewEntity((short)Obj3dType.o3d_planeOffset);
            ksPlaneOffsetDefinition planeDefinition = planeFormSurface.GetDefinition();
            planeDefinition.SetPlane(basePlane);
            planeDefinition.offset = offset;
            planeFormSurface.Create();
            return planeFormSurface;
        }

        /// <summary>
        /// Расчет точек конфетной формы
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="formTotalLength"></param>
        /// <param name="formTotalWidth"></param>
        private void InitCandySettingsPoints(ref double[] X, ref double[] Y, 
            double formTotalLength, double formTotalWidth)
        {
            X = new double[]
            {
                -formTotalLength / 2,
                -formTotalLength / 2,
                formTotalLength / 2,
                formTotalLength / 2,
                -formTotalLength / 2
            };

            Y = new double[]
            {
                -formTotalWidth / 2,
                formTotalWidth / 2,
                formTotalWidth / 2,
                -formTotalWidth / 2,
                -formTotalWidth / 2
            };
        }

        /// <summary>
        /// Расчет точек прямоугольной конфеты
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="formTotalLength"></param>
        /// <param name="formTotalWidth"></param>
        /// <param name="candySettings"></param>
        /// <param name="candy"></param>
        private void InitRectCandyPoints(ref double[] X, ref double[] Y, 
            double formTotalLength, double formTotalWidth, 
            CandySettings candySettings, ICandy candy)
        {
            X = new double[]
                {
                (-formTotalLength / 2) + candySettings.FormDepthByLength,
                (-formTotalLength / 2) + candySettings.FormDepthByLength,
                (-formTotalLength / 2) + candySettings.FormDepthByLength
                    + candy.Width,
                (-formTotalLength / 2) + candySettings.FormDepthByLength
                    + candy.Width,
                (-formTotalLength / 2) + candySettings.FormDepthByLength
                };
            Y = new double[]
            {
                (-formTotalWidth / 2) + candySettings.FormDepthByWidth,
                (-formTotalWidth / 2) + candySettings.FormDepthByWidth
                    + candy.Length,
                (-formTotalWidth / 2) + candySettings.FormDepthByWidth
                    + candy.Length,
                (-formTotalWidth / 2) + candySettings.FormDepthByWidth,
                (-formTotalWidth / 2) + candySettings.FormDepthByWidth
            };
        }

        /// <summary>
        /// Расчет точек цилиндрической конфеты
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="formTotalLength"></param>
        /// <param name="formTotalWidth"></param>
        /// <param name="candySettings"></param>
        /// <param name="candy"></param>
        private void InitCylinderCandyPoints(ref double[] X, ref double[] Y, 
            double formTotalLength, double formTotalWidth, 
            CandySettings candySettings, ICandy candy)
        {
            X = new double[]
                {
                (-formTotalLength / 2) + candySettings.FormDepthByLength + candy.Width/2,
                (-formTotalLength / 2) + candySettings.FormDepthByLength + candy.Width/2,
                (-formTotalLength / 2) + candySettings.FormDepthByLength
                    + candy.Width,
                (-formTotalLength / 2) + candySettings.FormDepthByLength
                    + candy.Width,
                (-formTotalLength / 2) + candySettings.FormDepthByLength + candy.Width/2
                };
            Y = new double[]
            {
                (-formTotalWidth / 2) + candySettings.FormDepthByWidth,
                (-formTotalWidth / 2) + candySettings.FormDepthByWidth
                    + candy.Length,
                (-formTotalWidth / 2) + candySettings.FormDepthByWidth
                    + candy.Length,
                (-formTotalWidth / 2) + candySettings.FormDepthByWidth,
                (-formTotalWidth / 2) + candySettings.FormDepthByWidth
            };
        }

        private void CutExtrude(ksPart part, ksEntity sketch, double depth)
        {
            ksEntity cutExtrude = part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition cutextrDefinition = cutExtrude.GetDefinition();
            cutextrDefinition.directionType = (short)Direction_Type.dtNormal;
            cutextrDefinition.SetSketch(sketch);
            ksExtrusionParam cutExtrudeParam = cutextrDefinition.ExtrusionParam();
            cutExtrudeParam.depthNormal = depth;
            cutExtrude.Create();
        }
    }
}
