using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Square : Figure
    {
        public double b;

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
