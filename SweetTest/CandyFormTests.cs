using System;

using NUnit.Framework;

using SweetKompasPlugin.Model;
using SweetKompasPlugin.Model.Exceptions;

namespace SweetTest
{
    [TestFixture]
    public class CandyFormTests
    {
        [TestCase(20, 5, 5, 5, 
            TestName = "(Позитивный) Максимальные параметры конструктора")]
        [TestCase(8, 3, 3, 3,
            TestName = "(Позитивный) Минимальные параметры конструктора")]
        [TestCase(14, 4, 4, 4, 
            TestName = "(Позитивный) Средние параметры конструктора")]
        [Test]
        public void TestPositiveCandyFormConstructor(
            int candyCount, double formDepthByLength, 
            double formDepthByWidth, double formDepthByHeight)
        {
            Assert.DoesNotThrow((() =>
            {
                new CandyForm(candyCount,formDepthByLength, 
                    formDepthByWidth, formDepthByHeight);
            }
            ));
        }

        [TestCase(7, 5, 5, 5, typeof(CandyCountException),
            TestName = "(Негативный) Количество конфет меньше")]
        [TestCase(21, 5, 5, 5, typeof(CandyCountException),
            TestName = "(Негативный) Количество конфет больше")]
        [TestCase(int.MinValue, 5, 5, 5, typeof(CandyCountException),
            TestName = "(Негативный) Количество конфет int.MinValue")]
        [TestCase(int.MaxValue, 5, 5, 5, typeof(CandyCountException),
            TestName = "(Негативный) Количество конфет int.MaxValue")]

        [TestCase(20, 2, 5, 5, typeof(FormDepthByLengthException),
            TestName = "(Негативный) Толщина формы по длине меньше")]
        [TestCase(20, 6, 5, 5, typeof(FormDepthByLengthException),
            TestName = "(Негативный) Толщина формы по длине больше")]
        [TestCase(20, double.NaN, 5, 5, typeof(FormDepthByLengthException),
            TestName = "(Негативный) Толщина формы по длине не число")]
        [TestCase(20, double.MinValue, 5, 5, typeof(FormDepthByLengthException),
            TestName = "(Негативный) Толщина формы по длине double.minvalue")]
        [TestCase(20, double.MaxValue, 5, 5, typeof(FormDepthByLengthException),
            TestName = "(Негативный) Толщина формы по длине double.maxvalue")]
        [TestCase(20, double.NegativeInfinity, 5, 5, typeof(FormDepthByLengthException),
            TestName = "(Негативный) Толщина формы по длине double.negativeinfinity")]
        [TestCase(20, double.PositiveInfinity, 5, 5, typeof(FormDepthByLengthException),
            TestName = "(Негативный) Толщина формы по длине double.positiveinfinity")]

        [TestCase(20, 5, 2, 5, typeof(FormDepthByWidthException),
            TestName = "(Негативный) Толщина формы по ширине меньше")]
        [TestCase(20, 5, 6, 5, typeof(FormDepthByWidthException),
            TestName = "(Негативный) Толщина формы по ширине больше")]
        [TestCase(20, 5, double.NaN, 5, typeof(FormDepthByWidthException),
            TestName = "(Негативный) Толщина формы по ширине не число")]
        [TestCase(20, 5, double.MinValue, 5, typeof(FormDepthByWidthException),
            TestName = "(Негативный) Толщина формы по ширине double.minvalue")]
        [TestCase(20, 5, double.MaxValue, 5, typeof(FormDepthByWidthException),
            TestName = "(Негативный) Толщина формы по ширине double.maxvalue")]
        [TestCase(20, 5, double.NegativeInfinity, 5, typeof(FormDepthByWidthException),
            TestName = "(Негативный) Толщина формы по ширине double.negativeinfinity")]
        [TestCase(20, 5, double.PositiveInfinity, 5, typeof(FormDepthByWidthException),
            TestName = "(Негативный) Толщина формы по ширине double.positiveinfinity")]

        [TestCase(20, 5, 5, 2, typeof(FormDepthByHeightException),
            TestName = "(Негативный) Толщина формы по высоте меньше")]
        [TestCase(20, 5, 5, 6, typeof(FormDepthByHeightException),
            TestName = "(Негативный) Толщина формы по высоте больше")]
        [TestCase(20, 5, 5, double.NaN, typeof(FormDepthByHeightException),
            TestName = "(Негативный) Толщина формы по высоте не число")]
        [TestCase(20, 5, 5, double.MinValue, typeof(FormDepthByHeightException),
            TestName = "(Негативный) Толщина формы по высоте double.minvalue")]
        [TestCase(20, 5, 5, double.MaxValue, typeof(FormDepthByHeightException),
            TestName = "(Негативный) Толщина формы по высоте double.maxvalue")]
        [TestCase(20, 5, 5, double.NegativeInfinity, typeof(FormDepthByHeightException),
            TestName = "(Негативный) Толщина формы по высоте double.negativeinfinity")]
        [TestCase(20, 5, 5, double.PositiveInfinity, typeof(FormDepthByHeightException),
            TestName = "(Негативный) Толщина формы по высоте double.positiveinfinity")]

        [Test]
        public void TestNegativeCandyFormConstructor(
            int candyCount, double formDepthByLength, 
            double formDepthByWidth, double formDepthByHeight, 
            Type exceptionType)
        {
            Assert.That(() =>
            {
                new CandyForm(candyCount, formDepthByLength,
                    formDepthByWidth, formDepthByHeight);
            }, Throws.TypeOf(exceptionType));
        }

        [TestCase(20, TestName = "(Позитивный) Получение количества конфет")]
        [Test]
        public void TestCandyCountGet(double value)
        {
            CandyForm candyForm =
                new CandyForm(20, 5, 5, 5);
            Assert.AreEqual(value, candyForm.CandyCount);
        }

        [TestCase(5, TestName = "(Позитивный) Получение толщины формы по длине")]
        [Test]
        public void TestFormDepthByLengthGet(double value)
        {
            CandyForm candyForm =
                new CandyForm(20, 5, 5, 5);
            Assert.AreEqual(value, candyForm.FormDepthByLength);
        }

        [TestCase(5, TestName = "(Позитивный) Получение толщины формы по ширине")]
        [Test]
        public void TestFormDepthByWidthGet(double value)
        {
            CandyForm candyForm =
                new CandyForm(20, 5, 5, 5);
            Assert.AreEqual(value, candyForm.FormDepthByWidth);
        }

        [TestCase(5, TestName = "(Позитивный) Получение толщины формы по высоте")]
        [Test]
        public void TestFormDepthByHeightGet(double value)
        {
            CandyForm candyForm =
                new CandyForm(20, 5, 5, 5);
            Assert.AreEqual(value, candyForm.FormDepthByHeight);
        }
    }
}
