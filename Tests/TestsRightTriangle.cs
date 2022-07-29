using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Mindbox_Quest;

namespace Tests
{
    public class TestsRightTriangle
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void TestRightTriangle()
        {
            Triangle t = new Triangle(3, 4, 5);
            Assert.True(FigureArea.IsRight(t));
        }
        [Test]
        public void TestNotRightTriangle()
        {
            Triangle t = new Triangle(3, 7, 5);
            Assert.False(FigureArea.IsRight(t));
        }
    }
}
