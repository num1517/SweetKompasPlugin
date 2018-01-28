using System;

using NUnit.Framework;

using SweetKompasPlugin.Model;
using SweetKompasPlugin.Model.Exceptions;

namespace SweetTest
{
    [TestFixture]
    class CylinderCandyTests
    {
        [TestCase(10, 20,
            TestName = "(Позитивный) Максимальные параметры конструктора цилиндрической конфеты")]
        [TestCase(25, 50,
            TestName = "(Позитивный) Минимальные параметры конструктора цилиндрической конфеты")]
        [TestCase(17.5, 35,
            TestName = "(Позитивный) Средние параметры конструктора цилиндрической конфеты")]
        [Test]
        public void TestPositiveCylinderCandyConstructor(double r, double length)
        {
            Assert.DoesNotThrow((() =>
            {
                new CylinderCandy(r, length);
            }
            ));
        }

        [TestCase(9, 50, typeof(CandyRadiusException),
            TestName = "(Негативный) Радиус конфеты меньше")]
        [TestCase(26, 50, typeof(CandyRadiusException),
            TestName = "(Негативный) Радиус конфеты больше")]
        [TestCase(double.NaN, 50, typeof(CandyRadiusException),
            TestName = "(Негативный) Радиус конфеты не число")]
        [TestCase(double.MinValue, 50, typeof(CandyRadiusException),
            TestName = "(Негативный) Радиус конфеты double.MinValue")]
        [TestCase(double.MinValue, 50, typeof(CandyRadiusException),
            TestName = "(Негативный) Радиус конфеты double.MaxValue")]
        [TestCase(double.NegativeInfinity, 50, typeof(CandyRadiusException),
            TestName = "(Негативный) Радиус конфеты double.negativeinfinity")]
        [TestCase(double.PositiveInfinity, 50, typeof(CandyRadiusException),
            TestName = "(Негативный) Радиус конфеты double.positiveinfinity")]

        [TestCase(25, 19, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты меньше")]
        [TestCase(25, 51, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты больше")]
        [TestCase(25, double.NaN, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты не число")]
        [TestCase(25, double.MinValue, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты double.MinValue")]
        [TestCase(25, double.MaxValue, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты double.MaxValue")]
        [TestCase(25, double.NegativeInfinity, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты double.negativeinfinity")]
        [TestCase(25, double.PositiveInfinity, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты double.positiveinfinity")]

        [Test]
        public void TestNegativeCylinderCandyConstructor(double r, double length, Type exceptionType)
        {
            Assert.That(() =>
            {
                new CylinderCandy(r, length);
            }, Throws.TypeOf(exceptionType));
        }

        [TestCase(25, TestName = "(Позитивный) Получение радиуса сферической конфеты")]
        [Test]
        public void TestCylinderCandyRadiusGet(double value)
        {
            CylinderCandy candy = new CylinderCandy(25, 50);
            Assert.AreEqual(value, candy.R);
        }

        [TestCase(50, TestName = "(Позитивный) Получение длины сферической конфеты")]
        [Test]
        public void TestCylinderCandyLengthGet(double value)
        {
            CylinderCandy candy = new CylinderCandy(25, 50);
            Assert.AreEqual(value, candy.Length);
        }
    }
}
