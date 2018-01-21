using System;

using Kompas6API5;
using Kompas6Constants3D;

namespace SweetKompasPlugin.Model
{
    public class KompasWrapper
    {
        private KompasObject _kompas = null;

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
                        tried++;
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

        public void BuildCandyForm (CandyForm candyForm)
        {
            if (_kompas == null)
            {
                throw new Exception(
                    "Невозможно построить деталь. Нет связи с КОМПАС 3D.");
            }

            // Рисуем форму

            double formTotalLength = candyForm.FormDepthByLength
                + (candyForm.FormDepthByLength * candyForm.CandyCount / 2)
                + (candyForm.CandyWidth * candyForm.CandyCount / 2);
            double formTotalWidth = (candyForm.FormDepthByWidth * 3)
                + (candyForm.CandyLength * 2);

            // 5 точка равна 1
            double[] formXPoints = new double[]
            {
                -formTotalLength / 2,
                -formTotalLength / 2,
                formTotalLength / 2,
                formTotalLength / 2,
                -formTotalLength / 2
            };
            double[] formYPoints = new double[]
            {
                -formTotalWidth / 2,
                formTotalWidth / 2,
                formTotalWidth / 2,
                -formTotalWidth / 2,
                -formTotalWidth / 2
            };

            // Создание документа в компасе

            ksDocument3D document3D = _kompas.Document3D();
            document3D.Create();

            // Создание и настройка эскиза на базовой плоскости XOY

            ksPart part = document3D.GetPart((short)Part_Type.pTop_Part);
            ksEntity planeXOY = part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            ksEntity formSketch = part.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDefinition = formSketch.GetDefinition();
            sketchDefinition.SetPlane(planeXOY);
            formSketch.Create();

            // Входим в режим редактирования эскиза
            ksDocument2D document2D = sketchDefinition.BeginEdit();

            // Соединение точек формы отрезками
            for (int i = 0; i < 4; i++)
            {
                document2D.ksLineSeg(formXPoints[i], formYPoints[i],
                    formXPoints[i + 1], formYPoints[i + 1], 1);
            }

            // Выходим из режима редактирования эскиза
            sketchDefinition.EndEdit();

            // Выдавливание формы

            ksEntity formExtrude = part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            ksBossExtrusionDefinition formExtrudeDefinition = formExtrude.GetDefinition();
            formExtrudeDefinition.directionType = (short)Direction_Type.dtMiddlePlane;
            formExtrudeDefinition.SetSketch(formSketch);
            ksExtrusionParam extrudeParam = formExtrudeDefinition.ExtrusionParam();
            extrudeParam.depthNormal = candyForm.CandyHeight + candyForm.FormDepthByHeight;
            formExtrude.Create();

            // Создание смещенной плоскости на поверхности формы

            ksEntity planeFormSurface = part.NewEntity((short)Obj3dType.o3d_planeOffset);
            ksPlaneOffsetDefinition planeDefinition = planeFormSurface.GetDefinition();
            planeDefinition.SetPlane(part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY));
            planeDefinition.offset = (candyForm.CandyHeight + candyForm.FormDepthByHeight) / 2;
            planeFormSurface.Create();

            // Создание и настройка эскиза на поверхности формы (смещенной плоскости)

            ksEntity formSurfaceSketch = part.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition formSurfaceSketchDefinition = formSurfaceSketch.GetDefinition();
            formSurfaceSketchDefinition.SetPlane(planeFormSurface);
            formSurfaceSketch.Create();

            // Входим в режим редактирования эскиза
            ksDocument2D formSurfaceDocument2D = formSurfaceSketchDefinition.BeginEdit();

            // Расчитаем положение первой конфеты
            // Положение других конфет расчитаем путем сдвига первой

            double[] candyXPoints = new double[]
            {
                (-formTotalLength / 2) + candyForm.FormDepthByLength,
                (-formTotalLength / 2) + candyForm.FormDepthByLength,
                (-formTotalLength / 2) + candyForm.FormDepthByLength
                    + candyForm.CandyWidth,
                (-formTotalLength / 2) + candyForm.FormDepthByLength
                    + candyForm.CandyWidth,
                (-formTotalLength / 2) + candyForm.FormDepthByLength
            };
            double[] candyYPoints = new double[]
            {
                (-formTotalWidth / 2) + candyForm.FormDepthByWidth,
                (-formTotalWidth / 2) + candyForm.FormDepthByWidth
                    + candyForm.CandyLength,
                (-formTotalWidth / 2) + candyForm.FormDepthByWidth
                    + candyForm.CandyLength,
                (-formTotalWidth / 2) + candyForm.FormDepthByWidth,
                (-formTotalWidth / 2) + candyForm.FormDepthByWidth
            };

            // Рисуем конфеты
            for (int i = 0; i < candyForm.CandyCount / 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        formSurfaceDocument2D.ksLineSeg(candyXPoints[k], candyYPoints[k], 
                            candyXPoints[k + 1], candyYPoints[k + 1], 1);
                    }
                    candyYPoints = GetShiftedArray(candyYPoints, 
                        candyForm.CandyLength + candyForm.FormDepthByWidth);
                }
                candyYPoints = GetShiftedArray(candyYPoints, 
                    -2 * (candyForm.CandyLength + candyForm.FormDepthByWidth));
                candyXPoints = GetShiftedArray(candyXPoints, 
                    candyForm.CandyWidth + candyForm.FormDepthByLength);
            }

            // Выходим из режима редактирования эскиза
            formSurfaceSketchDefinition.EndEdit();

            // Вырезаем конфетки ^_^

            ksEntity cutExtrude = part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition cutextrDefinition = cutExtrude.GetDefinition();
            cutextrDefinition.directionType = (short)Direction_Type.dtNormal;
            cutextrDefinition.SetSketch(formSurfaceSketch);
            ksExtrusionParam cutExtrudeParam = cutextrDefinition.ExtrusionParam();
            cutExtrudeParam.depthNormal = candyForm.CandyHeight;
            cutExtrude.Create();
        }

        private double[] GetShiftedArray (double[] array, double shift)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] += shift;
            }
            return array;
        }
    }
}
