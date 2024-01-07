using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Figure
    {
        public double a; // сторона фигуры

        public virtual double P()
        {
            return a;
        }

        public virtual double S()
        {
            return 0;
        }
    }
}
