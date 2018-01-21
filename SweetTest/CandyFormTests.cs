using System;

using NUnit.Framework;

using SweetKompasPlugin.Model;
using SweetKompasPlugin.Model.Exceptions;

namespace SweetTest
{
    [TestFixture]
    public class CandyFormTests
    {
        [TestCase(20, 50, 50, 30, 5, 5, 5, 
            TestName = "(Позитивный) Максимальные параметры консруктора")]
        [TestCase(8, 20, 20, 15, 3, 3, 3,
            TestName = "(Позитивный) Минимальные параметры консруктора")]
        [TestCase(14, 35, 35, 22.5, 4, 4, 4, 
            TestName = "(Позитивный) Средние параметры консруктора")]
        [Test]
        public void TestPositiveCandyFormConstructor(
            int candyCount, double candyLength,
            double candyWidth, double candyHeight,
            double formDepthByLength, double formDepthByWidth,
            double formDepthByHeight)
        {
            Assert.DoesNotThrow((() =>
            {
                new CandyForm(candyCount, candyLength,
                    candyWidth, candyHeight, formDepthByLength, 
                    formDepthByWidth, formDepthByHeight);
            }
            ));
        }

        [TestCase(7, 50, 50, 30, 5, 5, 5, typeof(CandyCountException),
            TestName = "(Негативный) Количество конфет меньше")]
        [TestCase(21, 50, 50, 30, 5, 5, 5, typeof(CandyCountException),
            TestName = "(Негативный) Количество конфет больше")]
        [TestCase(int.MinValue, 50, 50, 30, 5, 5, 5, typeof(CandyCountException),
            TestName = "(Негативный) Количество конфет int.MinValue")]
        [TestCase(int.MaxValue, 50, 50, 30, 5, 5, 5, typeof(CandyCountException),
            TestName = "(Негативный) Количество конфет int.MaxValue")]

        [TestCase(20, 19, 50, 30, 5, 5, 5, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты меньше")]
        [TestCase(20, 51, 50, 30, 5, 5, 5, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты больше")]
        [TestCase(20, double.NaN, 50, 30, 5, 5, 5, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты не число")]
        [TestCase(20, double.MinValue, 50, 30, 5, 5, 5, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты double.minvalue")]
        [TestCase(20, double.MaxValue, 50, 30, 5, 5, 5, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты double.maxvalue")]
        [TestCase(20, double.NegativeInfinity, 50, 30, 5, 5, 5, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты double.negativeinfinity")]
        [TestCase(20, double.PositiveInfinity, 50, 30, 5, 5, 5, typeof(CandyLengthException),
            TestName = "(Негативный) Длина конфеты double.positiveinfinity")]

        [TestCase(20, 50, 19, 30, 5, 5, 5, typeof(CandyWidthException),
            TestName = "(Негативный) Ширина конфеты меньше")]
        [TestCase(20, 50, 51, 30, 5, 5, 5, typeof(CandyWidthException),
            TestName = "(Негативный) Ширина конфеты больше")]
        [TestCase(20, 50, double.NaN, 30, 5, 5, 5, typeof(CandyWidthException),
            TestName = "(Негативный) Ширина конфеты не число")]
        [TestCase(20, 50, double.MinValue, 30, 5, 5, 5, typeof(CandyWidthException),
            TestName = "(Негативный) Ширина конфеты double.minvalue")]
        [TestCase(20, 50, double.MaxValue, 30, 5, 5, 5, typeof(CandyWidthException),
            TestName = "(Негативный) Ширина конфеты double.maxvalue")]
        [TestCase(20, 50, double.NegativeInfinity, 30, 5, 5, 5, typeof(CandyWidthException),
            TestName = "(Негативный) Ширина конфеты double.negativeinfinity")]
        [TestCase(20, 50, double.PositiveInfinity, 30, 5, 5, 5, typeof(CandyWidthException),
            TestName = "(Негативный) Ширина конфеты double.positiveinfinity")]

        [TestCase(20, 50, 50, 14, 5, 5, 5, typeof(CandyHeightException),
            TestName = "(Негативный) Высота конфеты меньше")]
        [TestCase(20, 50, 50, 31, 5, 5, 5, typeof(CandyHeightException),
            TestName = "(Негативный) Высота конфеты больше")]
        [TestCase(20, 50, 50, double.NaN, 5, 5, 5, typeof(CandyHeightException),
            TestName = "(Негативный) Высота конфеты не число")]
        [TestCase(20, 50, 50, double.MinValue, 5, 5, 5, typeof(CandyHeightException),
            TestName = "(Негативный) Высота конфеты double.minvalue")]
        [TestCase(20, 50, 50, double.MaxValue, 5, 5, 5, typeof(CandyHeightException),
            TestName = "(Негативный) Высота конфеты double.maxvalue")]
        [TestCase(20, 50, 50, double.NegativeInfinity, 5, 5, 5, typeof(CandyHeightException),
            TestName = "(Негативный) Высота конфеты double.negativeinfinity")]
        [TestCase(20, 50, 50, double.PositiveInfinity, 5, 5, 5, typeof(CandyHeightException),
            TestName = "(Негативный) Высота конфеты double.positiveinfinity")]

        [TestCase(20, 50, 50, 30, 2, 5, 5, typeof(FormDepthByLengthException),
            TestName = "(Негативный) Толщина формы по длине меньше")]
        [TestCase(20, 50, 50, 30, 6, 5, 5, typeof(FormDepthByLengthException),
            TestName = "(Негативный) Толщина формы по длине больше")]
        [TestCase(20, 50, 50, 30, double.NaN, 5, 5, typeof(FormDepthByLengthException),
            TestName = "(Негативный) Толщина формы по длине не число")]
        [TestCase(20, 50, 50, 30, double.MinValue, 5, 5, typeof(FormDepthByLengthException),
            TestName = "(Негативный) Толщина формы по длине double.minvalue")]
        [TestCase(20, 50, 50, 30, double.MaxValue, 5, 5, typeof(FormDepthByLengthException),
            TestName = "(Негативный) Толщина формы по длине double.maxvalue")]
        [TestCase(20, 50, 50, 30, double.NegativeInfinity, 5, 5, typeof(FormDepthByLengthException),
            TestName = "(Негативный) Толщина формы по длине double.negativeinfinity")]
        [TestCase(20, 50, 50, 30, double.PositiveInfinity, 5, 5, typeof(FormDepthByLengthException),
            TestName = "(Негативный) Толщина формы по длине double.positiveinfinity")]

        [TestCase(20, 50, 50, 30, 5, 2, 5, typeof(FormDepthByWidthException),
            TestName = "(Негативный) Толщина формы по ширине меньше")]
        [TestCase(20, 50, 50, 30, 5, 6, 5, typeof(FormDepthByWidthException),
            TestName = "(Негативный) Толщина формы по ширине больше")]
        [TestCase(20, 50, 50, 30, 5, double.NaN, 5, typeof(FormDepthByWidthException),
            TestName = "(Негативный) Толщина формы по ширине не число")]
        [TestCase(20, 50, 50, 30, 5, double.MinValue, 5, typeof(FormDepthByWidthException),
            TestName = "(Негативный) Толщина формы по ширине double.minvalue")]
        [TestCase(20, 50, 50, 30, 5, double.MaxValue, 5, typeof(FormDepthByWidthException),
            TestName = "(Негативный) Толщина формы по ширине double.maxvalue")]
        [TestCase(20, 50, 50, 30, 5, double.NegativeInfinity, 5, typeof(FormDepthByWidthException),
            TestName = "(Негативный) Толщина формы по ширине double.negativeinfinity")]
        [TestCase(20, 50, 50, 30, 5, double.PositiveInfinity, 5, typeof(FormDepthByWidthException),
            TestName = "(Негативный) Толщина формы по ширине double.positiveinfinity")]

        [TestCase(20, 50, 50, 30, 5, 5, 2, typeof(FormDepthByHeightException),
            TestName = "(Негативный) Толщина формы по высоте меньше")]
        [TestCase(20, 50, 50, 30, 5, 5, 6, typeof(FormDepthByHeightException),
            TestName = "(Негативный) Толщина формы по высоте больше")]
        [TestCase(20, 50, 50, 30, 5, 5, double.NaN, typeof(FormDepthByHeightException),
            TestName = "(Негативный) Толщина формы по высоте не число")]
        [TestCase(20, 50, 50, 30, 5, 5, double.MinValue, typeof(FormDepthByHeightException),
            TestName = "(Негативный) Толщина формы по высоте double.minvalue")]
        [TestCase(20, 50, 50, 30, 5, 5, double.MaxValue, typeof(FormDepthByHeightException),
            TestName = "(Негативный) Толщина формы по высоте double.maxvalue")]
        [TestCase(20, 50, 50, 30, 5, 5, double.NegativeInfinity, typeof(FormDepthByHeightException),
            TestName = "(Негативный) Толщина формы по высоте double.negativeinfinity")]
        [TestCase(20, 50, 50, 30, 5, 5, double.PositiveInfinity, typeof(FormDepthByHeightException),
            TestName = "(Негативный) Толщина формы по высоте double.positiveinfinity")]

        [Test]
        public void TestNegativeCogwheelConstructor(
            int candyCount, double candyLength,
            double candyWidth, double candyHeight,
            double formDepthByLength, double formDepthByWidth,
            double formDepthByHeight, Type exceptionType)
        {
            Assert.That(() =>
            {
                new CandyForm(candyCount, candyLength,
                    candyWidth, candyHeight, formDepthByLength,
                    formDepthByWidth, formDepthByHeight);
            }, Throws.TypeOf(exceptionType));
        }

        [TestCase(20, TestName = "(Позитивный) Получение количества конфет")]
        [Test]
        public void TestCandyCountGet(double value)
        {
            CandyForm candyForm =
                new CandyForm(20, 50, 50, 30, 5, 5, 5);
            Assert.AreEqual(value, candyForm.CandyCount);
        }

        [TestCase(50, TestName = "(Позитивный) Получение длины конфеты")]
        [Test]
        public void TestCandyLengthGet(double value)
        {
            CandyForm candyForm =
                new CandyForm(20, 50, 50, 30, 5, 5, 5);
            Assert.AreEqual(value, candyForm.CandyLength);
        }

        [TestCase(50, TestName = "(Позитивный) Получение ширины конфеты")]
        [Test]
        public void TestCandyWidthGet(double value)
        {
            CandyForm candyForm =
                new CandyForm(20, 50, 50, 30, 5, 5, 5);
            Assert.AreEqual(value, candyForm.CandyWidth);
        }

        [TestCase(30, TestName = "(Позитивный) Получение высоты конфеты")]
        [Test]
        public void TestCandyHeightGet(double value)
        {
            CandyForm candyForm =
                new CandyForm(20, 50, 50, 30, 5, 5, 5);
            Assert.AreEqual(value, candyForm.CandyHeight);
        }

        [TestCase(5, TestName = "(Позитивный) Получение толщины формы по длине")]
        [Test]
        public void TestFormDepthByLengthGet(double value)
        {
            CandyForm candyForm =
                new CandyForm(20, 50, 50, 30, 5, 5, 5);
            Assert.AreEqual(value, candyForm.FormDepthByLength);
        }

        [TestCase(5, TestName = "(Позитивный) Получение толщины формы по ширине")]
        [Test]
        public void TestFormDepthByWidthGet(double value)
        {
            CandyForm candyForm =
                new CandyForm(20, 50, 50, 30, 5, 5, 5);
            Assert.AreEqual(value, candyForm.FormDepthByWidth);
        }

        [TestCase(5, TestName = "(Позитивный) Получение толщины формы по высоте")]
        [Test]
        public void TestFormDepthByHeightGet(double value)
        {
            CandyForm candyForm =
                new CandyForm(20, 50, 50, 30, 5, 5, 5);
            Assert.AreEqual(value, candyForm.FormDepthByHeight);
        }
    }
}
