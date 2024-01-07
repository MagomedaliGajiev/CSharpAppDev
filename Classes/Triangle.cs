using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Triangle : Figure
    {
        public double b;
        public double c;
        public string Name { get; set; }


        public double Dioganal()
        {
            return a;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
