using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Mindbox_Quest;

namespace Tests
{
    public class TestsTriangleArea
    {
        double eps = 0.001;
        [SetUp]
        public void Setup() { }

        [Test]
        public void NonExistentTriangle()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 3));
        }
        [Test]
        public void First8Second5Third5_RightArea12_Method1()
        {
            double RightArea = 12d;
            Triangle t = new Triangle(8, 5, 5);

            double Area = FigureArea.TriangleArea(t);

            Assert.True(Area - RightArea < eps);
        }
        [Test]
        public void First8Second5Third5_RightArea12_Method2()
        {
            double RightArea = 12d;
            Triangle t = new Triangle(8, 5, 5);

            double Area = FigureArea.TriangleArea(t.FirstSide, t.SecondSide, t.ThirdSide);

            Assert.True(Area - RightArea < eps);
        }
    }
}
