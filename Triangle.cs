using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mindbox_Quest
{
    public class Triangle
    {
        public double FirstSide { get; private set; }
        public double SecondSide { get; private set; }
        public double ThirdSide { get; private set; }

        public Triangle(double FirstSide, double SecondSide, double ThirdSide)
        {
            if ((FirstSide < 0 || SecondSide < 0 || ThirdSide < 0) || 
                (FirstSide + SecondSide <= ThirdSide ||
                FirstSide + ThirdSide <= SecondSide ||
                SecondSide + ThirdSide <= FirstSide)
                )
            {
                if (FirstSide < 0)
                    throw new ArgumentOutOfRangeException(nameof(FirstSide));
                if (SecondSide < 0)
                    throw new ArgumentOutOfRangeException(nameof(SecondSide));
                if (ThirdSide < 0)
                    throw new ArgumentOutOfRangeException(nameof(ThirdSide));
                if (FirstSide + SecondSide <= ThirdSide ||
                    FirstSide + ThirdSide <= SecondSide ||
                    SecondSide + ThirdSide <= FirstSide)
                    throw new ArgumentException("Такой треугольник не может существовать, т.к. сумма длин любых его двух сторон меньше третьей стороны");
            }
            else 
            {
                this.FirstSide = FirstSide;
                this.SecondSide = SecondSide;
                this.ThirdSide = ThirdSide;
            }
        }
    }
}
