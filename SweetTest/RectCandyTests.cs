using System;

using NUnit.Framework;

using SweetKompasPlugin.Model;
using SweetKompasPlugin.Model.Exceptions;

namespace SweetTest
{
    [TestFixture]
    public class RectCandyTests
    {
        [TestCase(50, 30, 50,
            TestName = "(Позитивный) Максимальные параметры конструктора квадратной конфеты")]
        [TestCase(20, 15, 20,
            TestName = "(Позитивный) Минимальные параметры конструктора квадратной конфеты")]
        [TestCase(35, 22.5, 35,
            TestName = "(Позитивный) Средние параметры конструктора квадратной конфеты")]
        [Test]
        public void TestPositiveRectCandyConstructor(
            double width, double height, double length)
        {
            Assert.DoesNotThrow((() =>
            {
                new RectCandy(width, height, length);
            }
            ));
        }

        [TestCase(19, 30, 50, typeof(CandyWidthException),
            TestName = "(Негативный) Ширина конфеты меньше")]
        [TestCase(51, 30, 50, typeof(CandyWidthException),
            TestName = "(Негативный) Ширина конфеты больше")]
        [TestCase(double.NaN, 30, 50, typeof(CandyWidthException),
            TestName = "(Негативный) Ширина конфеты не число")]
        [TestCase(double.MinValue, 30, 50, typeof(CandyWidthException),
            TestName = "(Негативный) Ширина конфеты double.MinValue")]
        [TestCase(double.MinValue, 30, 50, typeof(CandyWidthException),
            TestName = "(Негативный) Ширина конфеты double.MaxValue")]
        [TestCase(double.NegativeInfinity, 30, 50, typeof(CandyWidthException),
            TestName = "(Негативный) Ширина конфеты double.negativeinfinity")]
        [TestCase(double.PositiveInfinity, 30, 50, typeof(CandyWidthException),
            TestName = "(Негативный) Ширина конфеты double.positiveinfinity")]

        [TestCase(50, 14, 50, typeof(CandyHeightException),
            TestName = "(Негативный) Высота конфеты меньше")]
        [TestCase(50, 31, 50, typeof(CandyHeightException),
            TestName = "(Негативный) Высота конфеты больше")]
        [TestCase(50, double.NaN, 50, typeof(CandyHeightException),
            TestName = "(Негативный) Высота конфеты не число")]
        [TestCase(50, double.MinValue, 50, typeof(CandyHeightException),
            TestName = "(Негативный) Высота конфеты double.MinValue")]
        [TestCase(50, double.MaxValue, 50, typeof(CandyHeightException),
            TestName = "(Негативный) Высота конфеты double.MaxValue")]
        [TestCase(50, double.NegativeInfinity, 50, typeof(CandyHeightException),
            TestName = "(Негативный) Высота конфеты double.negativeinfinity")]
        [TestCase(50, double.PositiveInfinity, 50, typeof(CandyHeightException),
            TestName = "(Негативный) Высота конфеты double.positiveinfinity")]

        [TestCase(50, 30, 19, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты меньше")]
        [TestCase(50, 30, 51, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты больше")]
        [TestCase(50, 30, double.NaN, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты не число")]
        [TestCase(50, 30, double.MinValue, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты double.MinValue")]
        [TestCase(50, 30, double.MaxValue, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты double.MaxValue")]
        [TestCase(50, 30, double.NegativeInfinity, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты double.negativeinfinity")]
        [TestCase(50, 30, double.PositiveInfinity, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты double.positiveinfinity")]

        [Test]
        public void TestNegativeRectCandyConstructor(
            double width, double height, 
            double length, Type exceptionType)
        {
            Assert.That(() =>
            {
                new RectCandy(width, height, length);
            }, Throws.TypeOf(exceptionType));
        }

        [TestCase(50, TestName = "(Позитивный) Получение ширины квадратной конфеты")]
        [Test]
        public void TestRectCandyLengthGet(double value)
        {
            RectCandy candy = new RectCandy(50, 30, 50);
            Assert.AreEqual(value, candy.Width);
        }

        [TestCase(30, TestName = "(Позитивный) Получение высоты квадратной конфеты")]
        [Test]
        public void TestRectCandyWidthGet(double value)
        {
            RectCandy candy = new RectCandy(50, 30, 50);
            Assert.AreEqual(value, candy.Height);
        }

        [TestCase(50, TestName = "(Позитивный) Получение длины квадратной конфеты")]
        [Test]
        public void TestRectCandyHeightGet(double value)
        {
            RectCandy candy = new RectCandy(50, 30, 50);
            Assert.AreEqual(value, candy.Length);
        }
        
    }
}
