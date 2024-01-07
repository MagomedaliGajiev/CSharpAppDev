using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Square : Figure, IComparable<Square>
    {
        public double b;

        public int CompareTo(Square? other)
        {
            if (this.S() > other.S())
            {
                return 1;
            }
            else if (this.S() < other.S())
            {
                return -1;
            }
            return 0;
        }

        public override double P()
        {
            return a * 2 + b * 2;
        }

        public override double S()
        {
            return a * b;
        }
    }
}
