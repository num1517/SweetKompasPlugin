﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using SweetKompasPlugin.Model.Exceptions;
using Kompas6Constants3D;

namespace SweetKompasPlugin.Model
{
    class Sphere : CandyBase
    {
        private double _r;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        public Sphere(double r)
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
        public override double Width
        {
            get
            {
                return 2 * R;
            }
            protected set
            {

            }
        }


        /// <summary>
        /// Высота сферической конфеты
        /// </summary>
        public override double Height
        {
            get
            {
                return R;
            }
            protected set
            {

            }
        }

        /// <summary>
        /// Длина сферической конфеты
        /// </summary>
        public override double Length
        {
            get
            {
                return 2 * R;
            }
            protected set
            {

            }
        }

        public override void Build(ksPart part, ksEntity planeFormSurface, CandySettings candySettings, double formTotalLength, double formTotalWidth)
        {
            double x = -formTotalLength / 2 + candySettings.FormDepthByLength + Height;
            double y = -formTotalWidth / 2 + candySettings.FormDepthByWidth + Height;

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

                    formSurfaceDocument2D.ksArcByAngle(x, y, Height, 0, 180, 1, 1);
                    formSurfaceDocument2D.ksLineSeg(-Height + x, 0 + y, Height + x, 0 + y, 3);

                    // Выходим из режима редактирования эскиза
                    formSurfaceSketchDefinition.EndEdit();

                    CutRotated(part, formSurfaceSketch);

                    y += Length + candySettings.FormDepthByWidth;
                }
                y -= 2 * (Length + candySettings.FormDepthByWidth);
                x += Width + candySettings.FormDepthByLength;
            }
        }
    }
}