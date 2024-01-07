using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Triangle : ITest
    {
        public double a;
        public string Name { get; set; }

        public double Dioganal()
        {
            return a;
        }
    }
}
