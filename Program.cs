using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mindbox_Quest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Окружность
            Circle c = new Circle(Math.PI);
            double s_circle1 = FigureArea.CircleArea(c);
            double s_circle2 = FigureArea.CircleArea(c.Raduis);

            //Треугольник
            Triangle t = new Triangle(8, 5, Math.Sqrt(89));
            double s_trianle1 = FigureArea.TriangleArea(t);
            double s_trianle2 = FigureArea.TriangleArea(t.FirstSide, t.SecondSide, t.ThirdSide);

            //Любая фигура
            List<Point> Points = new List<Point>()
            {
                new Point(0, 0),
                new Point(0, 5),
                new Point(8, 0),
            };
            var s = FigureArea.AreaMonteCarlo(Points, 1000000);
        }
    }
}
