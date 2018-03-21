using System;

using Kompas6API5;
using Kompas6Constants3D;
using System.Collections.Generic;

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
        /// 
        /// </summary>
        private Dictionary<Type, int> _candyTypes = new Dictionary<Type, int>
        {
            { typeof(Rect), 0 },
            { typeof(Sphere), 1 },
            { typeof(Cylinder), 2 }
        };

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
        public void BuildCandySettings (CandySettings candySettings, CandyBase candy)
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
            CandyBase.DrawRect(formXPoints, formYPoints, document2D);

            // Выходим из режима редактирования эскиза
            sketchDefinition.EndEdit();

            // Выдавливание формы
            CandySettingsExtrude(part, formSketch, candy.Height + candySettings.FormDepthByHeight);

            // Создание смещенной плоскости на поверхности формы
            ksEntity planeFormSurface = CreateShiftedPlane(part, planeXOY, 
                (candy.Height + candySettings.FormDepthByHeight) / 2);

            candy.Build(part, planeFormSurface, candySettings, formTotalLength, formTotalWidth);
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
    }
}
