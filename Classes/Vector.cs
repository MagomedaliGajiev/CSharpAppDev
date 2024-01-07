using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Vector<T> where T : IComparable<T>
    {
        public T a;
        public T b;
        public T c;

        //public double Scalar2()
        //{
        //    ////return a * a + b * b + c * c;
        //}

        public override string ToString()
        {
            return $"({a}; {b}; {c})";
        }

    }
}
