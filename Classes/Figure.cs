using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Figure : ITest
    {
        public double a; // сторона фигуры

        public string Name { get; set ; }

        public double Dioganal()
        {
            return a;
        }

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
