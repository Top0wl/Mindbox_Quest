using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mindbox_Quest;
using NUnit.Framework;

namespace Tests
{
    public class TestsCircleArea
    {
        double eps = 0.001;
        [SetUp]
        public void Setup() { }

        [Test]
        public void NonExistentCircleWithNegativeRaduis()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));
        }
        [Test]
        public void Radius1_RightArea1PI_Method1()
        {
            double RightArea = Math.PI;
            Circle c = new Circle(1);


            double Area = FigureArea.CircleArea(c);


            Assert.True(Area - RightArea < eps);
        }
        [Test]
        public void Radius1_RightArea1PI_Method2()
        {
            double RightArea = Math.PI;
            Circle c = new Circle(1);


            double Area = FigureArea.CircleArea(c.Raduis);


            Assert.True(Area - RightArea < eps);
        }
        public void Radius2_RightArea12p5664()
        {
            double RightArea = 12.5664d;
            Circle c = new Circle(2);


            double Area = FigureArea.CircleArea(c);
            var q = Area - RightArea;

            Assert.True(Area - RightArea < eps);
        }
    }
}
