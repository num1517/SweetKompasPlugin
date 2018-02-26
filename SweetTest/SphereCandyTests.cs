using System;

using NUnit.Framework;

using SweetKompasPlugin.Model;
using SweetKompasPlugin.Model.Exceptions;

namespace SweetTest
{
    [TestFixture]
    public class SphereCandyTests
    {
        [TestCase(25,
            TestName = "(Позитивный) Максимальные параметры конструктора сферической конфеты")]
        [TestCase(10,
            TestName = "(Позитивный) Минимальные параметры конструктора сферической конфеты")]
        [TestCase(17.5,
            TestName = "(Позитивный) Средние параметры конструктора сферической конфеты")]
        [Test]
        public void TestPositiveSphereCandyConstructor(double r)
        {
            Assert.DoesNotThrow((() =>
            {
                new SphereCandy(r);
            }
            ));
        }

        [TestCase(9, typeof(CandyRadiusException),
            TestName = "(Негативный) Радиус конфеты меньше")]
        [TestCase(26, typeof(CandyRadiusException),
            TestName = "(Негативный) Радиус конфеты больше")]
        [TestCase(double.NaN, typeof(CandyRadiusException),
            TestName = "(Негативный) Радиус конфеты не число")]
        [TestCase(double.MinValue, typeof(CandyRadiusException),
            TestName = "(Негативный) Радиус конфеты double.MinValue")]
        [TestCase(double.MinValue, typeof(CandyRadiusException),
            TestName = "(Негативный) Радиус конфеты double.MaxValue")]
        [TestCase(double.NegativeInfinity, typeof(CandyRadiusException),
            TestName = "(Негативный) Радиус конфеты double.negativeinfinity")]
        [TestCase(double.PositiveInfinity, typeof(CandyRadiusException),
            TestName = "(Негативный) Радиус конфеты double.positiveinfinity")]

        [Test]
        public void TestNegativeSphereCandyConstructor(double r, Type exceptionType)
        {
            Assert.That(() =>
            {
                new SphereCandy(r);
            }, Throws.TypeOf(exceptionType));
        }

        [TestCase(50, TestName = "(Позитивный) Получение радиуса сферической конфеты")]
        [Test]
        public void TestSphereCandyRadiusGet(double value)
        {
            RectCandy candy = new RectCandy(50, 30, 50);
            Assert.AreEqual(value, candy.Width);
        }
    }
}
