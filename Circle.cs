using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mindbox_Quest
{
    public class Circle
    {
        public double Raduis { get; private set; }

        public Circle(double radius)
        {
            if (radius > 0)
            {
                this.Raduis = radius;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(radius));
            }
        }
    }
}
