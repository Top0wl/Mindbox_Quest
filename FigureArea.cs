using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mindbox_Quest
{
    public class FigureArea
    {
        /// <summary>
        /// Метод возвращает площадь окружности (S = Pi * R^2)
        /// </summary>
        /// <param name="circle">Экземпляр класса Circle</param>
        /// <returns>Площадь окружности</returns>
        public static double CircleArea(Circle circle) => Math.PI * circle.Raduis * circle.Raduis;
        /// <summary>
        /// Метод возвращает площадь окружности (S = Pi * R^2)
        /// </summary>
        /// <param name="raduis">Радиус окружности</param>
        /// <returns>Площадь окружности</returns>
        public static double CircleArea(double raduis) => Math.PI * raduis * raduis;
        /// <summary>
        /// Метод возвращает площадь треугольника (S = p(p-a)(p-b)(p-c), где p - полупериметр)
        /// </summary>
        /// <param name="triangle">Экземпляр класса Triangle</param>
        /// <returns>Площадь треугольника</returns>
        public static double TriangleArea(Triangle triangle)
        {
            double p = (triangle.FirstSide + triangle.SecondSide + triangle.ThirdSide) / 2;
            return Math.Sqrt(p * (p - triangle.FirstSide) * (p - triangle.SecondSide) * (p - triangle.ThirdSide));
        }
        /// <summary>
        /// Метод возвращает площадь треугольника (S = p(p-a)(p-b)(p-c), где p - полупериметр)
        /// </summary>
        /// <param name="FirstSide">Первая сторона треугольника</param>
        /// <param name="SecondSide">Вторая сторона треугольника</param>
        /// <param name="ThirdSide">Третья сторона треугольника</param>
        /// <returns></returns>
        public static double TriangleArea(double FirstSide, double SecondSide, double ThirdSide)
        {
            double p = (FirstSide + SecondSide + ThirdSide) / 2;
            return Math.Sqrt(p * (p - FirstSide) * (p - SecondSide) * (p - ThirdSide));
        }
        /// <summary>
        /// Классический метод Монте-Карло, который при большой точности позволяет вычислить площадь любой фигуры
        /// </summary>
        /// <param name="Points">Список точек фигуры</param>
        /// <param name="Accuracy">Точность. Ялвяется параметром количество точек, которые используются в методе монте-карло.
        /// Чем больше точек, тем точнее будет площадь</param>
        /// <returns>Площадь фигуры</returns>
        public static double AreaMonteCarlo(List<Point> Points, double Accuracy)
        {
            List<Point> PointsIn = new List<Point>();
            List<Point> PointsOut = new List<Point>();
            Random random = new Random();
            var xmin = Points.Min(p => p.X);
            var xmax = Points.Max(p => p.X);
            var ymin = Points.Min(p => p.Y);
            var ymax = Points.Max(p => p.Y);

            for (int i = 0; i < Accuracy; i++)
            {
                double x = xmin + random.NextDouble() * (xmax - xmin);
                double y = ymin + random.NextDouble() * (ymax - ymin);
                Point pnt = new Point(x, y);
                if (IsPointInPolygon4(Points, pnt))
                {
                    PointsIn.Add(pnt);
                }
                else
                {
                    PointsOut.Add(pnt);
                }
            }
            var a = (Math.Abs(xmin) + Math.Abs(xmax));
            var b = (Math.Abs(ymin) + Math.Abs(ymax));

            var S = a * b * ((double)PointsIn.Count / Accuracy);

            return S;
        }
        /// <summary>
        /// Метод *Монте-Карло*. Проверка вхождения точки в полигон
        /// </summary>
        /// <param name="polygon">Полигон</param>
        /// <param name="testPoint">Рандомная точка</param>
        /// <returns>True;False</returns>
        private static bool IsPointInPolygon4(List<Point> polygon, Point testPoint)
        {
            bool result = false;
            int j = polygon.Count() - 1;
            for (int i = 0; i < polygon.Count(); i++)
            {
                if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y || polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
                {
                    if (polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < testPoint.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
        /// <summary>
        /// Проверка треугольника на прямоугольность
        /// </summary>
        /// <param name="triangle">Экземпляр класса треугольник</param>
        /// <returns>True - если треугольник прямоугольный; False - если треугольник не прямоугольный;</returns>
        public static bool IsRight(Triangle triangle)
        {
            // Треугольник является прямоугольным, если a^2 + b^2 = c^2
            /* 
             * P.S.: Хочу отметить, что такая формула работает лишь в случае когда 'a' и 'b'
             * являются катетами, но в нашем классе треугольник, неизвестно является ли 1 сторона катетом,
             * поэтому мой длинный if покрывает все варианты...
             */
            if (
                triangle.FirstSide * triangle.FirstSide + triangle.SecondSide * triangle.SecondSide == triangle.ThirdSide * triangle.ThirdSide ||
                triangle.FirstSide * triangle.FirstSide + triangle.ThirdSide * triangle.ThirdSide == triangle.SecondSide * triangle.SecondSide ||
                triangle.ThirdSide * triangle.ThirdSide + triangle.SecondSide * triangle.SecondSide == triangle.FirstSide * triangle.FirstSide
                )
                return true;
            else 
                return false;
        }
    }
}
