using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Mindbox_Quest;

namespace Tests
{
    public class TestsPointFigureArea
    {
        double eps = 0.1;
        [SetUp]
        public void Setup() { }

        [Test]
        public void TestTriangleArea()
        {
            double RightArea = 20;
            //Прямоугольный треугольник
            List<Point> Points = new List<Point>()
            {
                new Point(0, 0),
                new Point(0, 5),
                new Point(8, 0),
            };
            var Area = FigureArea.AreaMonteCarlo(Points, 100000);

            Assert.True(Math.Abs(Area - RightArea) < eps);
        }
    }
}
