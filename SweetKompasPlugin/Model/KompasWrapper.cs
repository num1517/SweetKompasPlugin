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
                + (candyForm.FormDepthByLength * candyForm.CandyCount)
                + (candyForm.CandyWidth * candyForm.CandyCount);
            double formTotalWidth = candyForm.FormDepthByWidth
                + (candyForm.FormDepthByWidth * candyForm.CandyCount)
                + (candyForm.CandyLength * candyForm.CandyCount);

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
            ksEntity sketch = part.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDefinition = sketch.GetDefinition();
            sketchDefinition.SetPlane(planeXOY);
            sketch.Create();

            // Входим в режим редактирования эскиза
            ksDocument2D document2D = sketchDefinition.BeginEdit();

            // Соединение точек формы отрезками
            for (int i = 0; i < 4; i++)
            {
                document2D.ksLineSeg(formXPoints[i], formYPoints[i], formXPoints[i + 1], formYPoints[i + 1], 1);
            }

            // Выходим из режима редактирования эскиза
            sketchDefinition.EndEdit();
        }
    }
}
